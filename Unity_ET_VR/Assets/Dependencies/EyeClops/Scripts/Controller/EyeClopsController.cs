using System.Collections;
using EyeClops.Data;
using EyeClops.Internals;
using EyeClops.Manager;
using UnityEngine;
using ViveSR.anipal.Eye;
using CombinedEyeData = EyeClops.Data.CombinedEyeData;
using SingleEyeData = EyeClops.Data.SingleEyeData;

namespace EyeClops.Controller
{
    public class EyeClopsController : MonoBehaviour
    {
        private bool _eyeTrackerNotStarted = true;

        // Update is called once per frame
        void Update()
        {
            if (_eyeTrackerNotStarted)
            {
                EyeClopsManager.Instance.StartEyeTracker();
                EyeClopsManager.Instance.StartEyeTracking();
                _eyeTrackerNotStarted = false;
            }
        }

        //Ehemals: TrackerGeneratorClass
        private TimeStampType _timeStampType;
        private float _trackingFrequency;

        private void Start()
        {
            _timeStampType = EyeClopsManager.Instance.GetTimeStampType();
            _trackingFrequency = EyeClopsManager.Instance.GetHertzValue();
        }

        private IEnumerator RecordSnapshotData()
        {
            while (true)
            {
                GetBothEyeData(out var tickDataLeftEyeData, out var tickDataRightEyeData);
                var tickData = new EyeClopsData
                {
                    Timestamp = CreateTimeStamp(_timeStampType),
                    CombinedEyeData = GetCombinedEyeData(),
                    FocusData = GetFocusData(),
                    HeadData = GetHeadData(),
                    EventData = GetEventData(),
                    LeftEyeData = tickDataLeftEyeData,
                    RightEyeData = tickDataRightEyeData
                };
                EyeClopsManager.Instance.AddTrackingData(tickData);
                yield return new WaitForSeconds(_trackingFrequency);
            }
        }

        private string CreateTimeStamp(TimeStampType timeStampType)
        {
            string timeStamp = "";
            switch (_timeStampType)
            {
                case TimeStampType.RealTime:
                {
                    timeStamp = Time.realtimeSinceStartup.ToString();
                    break;
                }
                case TimeStampType.FrameCount:
                {
                    timeStamp = Time.frameCount.ToString();
                    break;
                }
                case TimeStampType.TobiiTimeStamp:
                {
                    EyeData eyeData = new EyeData();
                    SRanipal_Eye_API.GetEyeData(ref eyeData);
                    timeStamp = eyeData.timestamp.ToString();
                    break;
                }
                case TimeStampType.TobiiFrameSequence:
                {
                    EyeData eyeData = new EyeData();
                    SRanipal_Eye_API.GetEyeData(ref eyeData);
                    timeStamp = eyeData.frame_sequence.ToString();
                    break;
                }
            }

            return timeStamp;
        }

        public void StartRecording()
        {
            StartCoroutine(InitializeStartRecording());
        }

        private IEnumerator InitializeStartRecording()
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(RecordSnapshotData());
        }

        public void StopRecording()
        {
            StopCoroutine(RecordSnapshotData());
        }

        public void SetTimeStampType(TimeStampType timeStampType)
        {
            _timeStampType = timeStampType;
        }

        private FocusData GetFocusData()
        {
            FocusData focusData = new FocusData();
            Ray gazeRay = new Ray();
            FocusInfo focusInfo = new FocusInfo();

            UpdateFocusData(GazeIndex.LEFT, gazeRay, focusInfo, ref focusData.LeftFocusObject);
            UpdateFocusData(GazeIndex.RIGHT, gazeRay, focusInfo, ref focusData.RightFocusObject);
            UpdateFocusData(GazeIndex.COMBINE, gazeRay, focusInfo, ref focusData.CombinedFocusObject);

            return focusData;
        }

        private void UpdateFocusData(GazeIndex gazeIndex, Ray gazeRay, FocusInfo focusInfo,
            ref FocusObjectInformationData focusObjectInformation)
        {
            if (SRanipal_Eye.Focus(gazeIndex, out gazeRay, out focusInfo))
            {
                focusObjectInformation.FocusPosition = focusInfo.point;
                focusObjectInformation.FocusObjectName = focusInfo.transform.name;
                focusObjectInformation.ObjectColliderName = focusInfo.collider.name;
            }
        }


        private bool GetEventData()
        {
            bool eventData = false;
            return eventData;
        }

        private HeadData GetHeadData()
        {
            HeadData headData = new HeadData();

            var transform1 = EyeClopsManager.Instance.GetUsedCamera().transform;
            headData.HeadPosition = transform1.position;
            var rotation = transform1.rotation;
            headData.HeadRotation = rotation;
            headData.HeadRotationEular = rotation.eulerAngles;
            return headData;
        }

        private CombinedEyeData GetCombinedEyeData()
        {
            CombinedEyeData combinedEyeData = new CombinedEyeData();
            SRanipal_Eye.GetVerboseData(out var verboseData);
            combinedEyeData.ConvergenceDistance = verboseData.combined.convergence_distance_mm;
            GenerateGazeVector(GazeIndex.COMBINE, out combinedEyeData.GazeVector);
            return combinedEyeData;
        }

        private void GetBothEyeData(out SingleEyeData leftEyeData, out SingleEyeData rightEyeData)
        {
            SRanipal_Eye.GetVerboseData(out var verboseData);

            SRanipal_Eye.GetEyeOpenness(EyeIndex.LEFT, out leftEyeData.EyeOpenness);
            leftEyeData.PupilDiameter = verboseData.left.pupil_diameter_mm;
            leftEyeData.EyeOrigin = verboseData.left.gaze_origin_mm;
            leftEyeData.NormalizedGazeDirection = verboseData.left.gaze_direction_normalized;
            GenerateGazeVector(GazeIndex.LEFT, out leftEyeData.GazeVector);

            SRanipal_Eye.GetEyeOpenness(EyeIndex.RIGHT, out rightEyeData.EyeOpenness);
            rightEyeData.PupilDiameter = verboseData.right.pupil_diameter_mm;
            rightEyeData.EyeOrigin = verboseData.right.gaze_origin_mm;
            rightEyeData.NormalizedGazeDirection = verboseData.right.gaze_direction_normalized;
            GenerateGazeVector(GazeIndex.RIGHT, out rightEyeData.GazeVector);
        }

        private void GenerateGazeVector(GazeIndex gazeIndex, out Ray gazeVector)
        {
            SRanipal_Eye.GetGazeRay(gazeIndex, out var eyeRay);
            gazeVector = new Ray(EyeClopsManager.Instance.GetUsedCamera().transform.TransformPoint(eyeRay.origin),
                EyeClopsManager.Instance.GetUsedCamera().transform.TransformDirection(eyeRay.direction));
        }
    }
}