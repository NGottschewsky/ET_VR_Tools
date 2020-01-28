using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EyeClops.Controller;
using EyeClops.Data;
using EyeClops.DataLayer.DeSerializer;
using EyeClops.Internals;
using Tobii.XR;
using UnityEngine;
using UnityEngine.UI;
using ViveSR.anipal.Eye;

namespace EyeClops.Manager
{
    public class EyeClopsManager : MonoBehaviour
    {
        //TODO: Write a Deserilization Caller

        #region Singelton

        public static EyeClopsManager Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;

            if (usedCamera == null)
                usedCamera = Camera.main;
            
            DontDestroyOnLoad(this);
        }

        #endregion

        private List<EyeClopsData> _trackerData;

        private TobiiProvider _tobiiProvider;

        [Space] [Header("Tracker Speed in Hz")] [Range(1, 120)] [SerializeField]
        private float herztValue = 120;

        //The inner Herzt-Value which is calculated 1/hertzValue
        private float _herztValue;

        [SerializeField] private Camera usedCamera;
        [SerializeField] private string fileStoringPath;
        [SerializeField] private EyeClopsController eyeClopsController;
        [SerializeField] private EyeClopsGuiController eyeClopsGuiController;
        [SerializeField] private bool storeDataAsCsvFile = true;
        [SerializeField] private bool storeDataAsBinaryFile = true;

        private bool _calibrationGuiShouldBeShown;

        private bool _unpaused = true;
        private TimeStampType _timeStampType = TimeStampType.RealTime;

        private string _filePrefix;

        [SerializeField] private SRanipal_Eye_Framework sRanipalEyeFramework;

        // Start is called before the first frame update
        private void Start()
        {
            _trackerData = new List<EyeClopsData>();
            if (_tobiiProvider == null)
                StartCoroutine(InitializTobiiProvider());
            _tobiiProvider = new TobiiProvider();
            _herztValue = 1 / herztValue;
        }

        private IEnumerator InitializTobiiProvider()
        {
            yield return new WaitForEndOfFrame();
            _tobiiProvider = new TobiiProvider();
        }


        private void OnEnable()
        {
            if (SRanipal_Eye_Framework.Status == SRanipal_Eye_Framework.FrameworkStatus.STOP)
                sRanipalEyeFramework.StartFramework();
        }

        public void StartCalibration()
        {
            Debug.Log("Starte die Kalibrierung");
            eyeClopsGuiController.UpdateCalibrationStatusInfo(SRanipal_Eye.LaunchEyeCalibration());
        }

        public void StartEyeTracking()
        {
            eyeClopsController.StartRecording();
        }

        public void StopEyeTracking()
        {
            eyeClopsController.StopRecording();
        }

        public Camera GetUsedCamera()
        {
            return usedCamera;
        }

        public void StartValidation()
        {
            ValidationManager.instance.StartValidation();
        }

        public void StartEyeTracker()
        {
            _tobiiProvider = new TobiiProvider();
        }

        public Ray GetRayFromEye()
        {
            SRanipal_Eye.GetGazeRay(GazeIndex.COMBINE, out Ray ray);
            return ray;
        }

        public float GetHertzValue()
        {
            return _herztValue;
        }

        public void SaveEyeTrackingData(string filePrefix)
        {
            StopEyeTracking();
            if (filePrefix != null)
                _filePrefix = filePrefix;
            if (_filePrefix == null)
                DataIOManager.Instance.SaveEyeTrackingData();
            else
                DataIOManager.Instance.SaveEyeTrackingData(_filePrefix);
        }

        public List<EyeClopsValidationData> GetValidationData()
        {
            return ValidationManager.instance.GetValidationDates();
        }

        public Dictionary<int, Dictionary<string, List<GazeValidationData>>> GetGazeValidationData()
        {
            return ValidationManager.instance.GetGazeValidationData();
        }

        public List<EyeClopsData> GetTrackingDataFromGenerator()
        {
            return _trackerData;
        }

        public void AddTrackingData(EyeClopsData tickData)
        {
            if (_trackerData == null)
            {
                _trackerData = new List<EyeClopsData>();
            }

            _trackerData.Add(tickData);
        }

        public string GetFileStoringPath()
        {
            return fileStoringPath;
        }

        public void UpdateShowValidationResults(List<EyeClopsValidationData> lastValidationData)
        {
            if (eyeClopsGuiController != null)
                eyeClopsGuiController.UpdateValidationPointData(lastValidationData);
        }

        public void PauseContinueEyeTracking(Text buttonText)
        {
            _unpaused = !_unpaused;
            if (!_unpaused)
            {
                PauseEyeTracker();
                buttonText.text = "Continue";
            }
            else
            {
                ContinueEyeTracker();
                buttonText.text = "Pause";
            }
        }

        public void PauseEyeTracker()
        {
            _unpaused = true;
            StopEyeTracking();
        }

        public void ContinueEyeTracker()
        {
            _unpaused = false;
            StartEyeTracking();
        }

        public List<EyeClopsData> GetEyeTrackerData()
        {
            return _trackerData;
        }

        public TimeStampType GetTimeStampType()
        {
            return _timeStampType;
        }

        public void StoreAllData(string storePath, string prefix)
        {
            SetStorePath(storePath);
            SaveEyeTrackingData(prefix);
        }

        public void SetStorePath(string storePath)
        {
            if (storePath != null)
                fileStoringPath = storePath;
        }

        public void SetFilePrefix(string prefix)
        {
            if (prefix != null)
                _filePrefix = prefix;
        }

        public void SetTimeStampType(TimeStampType timeStampType)
        {
            this._timeStampType = timeStampType;
        }

        public void RequestLastEyePosition(out Ray combinedEyeGazeVector,
            out Vector3 leftEyePosition, out Ray leftEyeGazeVector,
            out Vector3 rightEyePosition, out Ray rightEyeGazeVector
        )
        {
            //TODO: maybe by a coroutine, because of possible interruption with the writing task
            EyeClopsData eyeClopsData = _trackerData[_trackerData.Count - 1];
            combinedEyeGazeVector = eyeClopsData.CombinedEyeData.GazeVector;
            leftEyePosition = eyeClopsData.LeftEyeData.EyeOrigin;
            leftEyeGazeVector = eyeClopsData.LeftEyeData.GazeVector;
            rightEyePosition = eyeClopsData.RightEyeData.EyeOrigin;
            rightEyeGazeVector = eyeClopsData.RightEyeData.GazeVector;
        }

        public void ShowEyeOpenness(out float leftEyeOpenness, out float rightEyeOpenness)
        {
            var eyeTrackingData = _trackerData[_trackerData.Count - 1];
            leftEyeOpenness = eyeTrackingData.LeftEyeData.EyeOpenness;
            rightEyeOpenness = eyeTrackingData.RightEyeData.EyeOpenness;
        }

        public bool StoreDataAsBinaryFile()
        {
            return storeDataAsBinaryFile;
        }

        public bool StoreDataAsCsvFile()
        {
            return storeDataAsCsvFile;
        }

        public void ResetTrackingData()
        {
            _trackerData = new List<EyeClopsData>();
        }

        public string GetLastTimeStamp()
        {
            return _trackerData.Count > 0 ?  _trackerData.Last().Timestamp : "NoData";
        }

        public void GetLastCombinedEyeFocusedObject(out string objectName, out Vector3 objectPosition)
        {
            var eyeClopsData = _trackerData[_trackerData.Count -1];
            objectName = eyeClopsData.FocusData.CombinedFocusObject.FocusObjectName;
            objectPosition = eyeClopsData.FocusData.CombinedFocusObject.FocusPosition;
        }

        public void SetUsedCamera(Camera updateCamera)
        {
            usedCamera = updateCamera;
        }

        public void CheckIfEyeTrackFrameworkIsRunning()
        {
            if (SRanipal_Eye_Framework.Status == SRanipal_Eye_Framework.FrameworkStatus.STOP)
                sRanipalEyeFramework.StartFramework();
        }
    }
}