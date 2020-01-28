using EyeClops.Data;
using EyeClops.Internals;
using EyeClops.Manager;
using UnityEngine;

namespace EyeClops
{
    public static class EyeClopsConnector
    {
        public static void InitiateEyeTracker(string storePath = null, string prefix = null,
            TimeStampType timeStampType = TimeStampType.RealTime)
        {
            if (storePath != null)
                EyeClopsManager.Instance.SetStorePath(storePath);
            if (prefix != null)
            {
                EyeClopsManager.Instance.SetFilePrefix(prefix);
            }

            EyeClopsManager.Instance.SetTimeStampType(timeStampType);
        }

        public static void PauseEyeTracker()
        {
            EyeClopsManager.Instance.PauseEyeTracker();
        }

        public static void ContinueEyeTracker()
        {
            EyeClopsManager.Instance.ContinueEyeTracker();
        }

        public static void StartCalibrateEyeTracker()
        {
            EyeClopsManager.Instance.StartCalibration();
        }

        public static void StartValidationEyeTracker()
        {
            EyeClopsManager.Instance.StartValidation();
        }

        public static void StoreDataComplete(string storePath = null, string prefix = null)
        {
            EyeClopsManager.Instance.StoreAllData(storePath, prefix);
        }

        public static void RequestLastEyePosition(out Ray combinedEyeGazeVector,
            out Vector3 leftEyePosition, out Ray leftEyeGazeVector,
            out Vector3 rightEyePosition, out Ray rightEyeGazeVector)
        {
            EyeClopsManager.Instance.RequestLastEyePosition(out combinedEyeGazeVector,
                out leftEyePosition, out leftEyeGazeVector,
                out rightEyePosition, out rightEyeGazeVector);
        }

        public static float EyeTrackerFrequency()
        {
            return EyeClopsManager.Instance.GetHertzValue();
        }

        public static void ShowEyeOpenness(out float leftEyeOpenness, out float rightEyeOpenness)
        {
            EyeClopsManager.Instance.ShowEyeOpenness(out leftEyeOpenness, out rightEyeOpenness);
        }

        public static void ResetEyeClopsData()
        {
            EyeClopsManager.Instance.ResetTrackingData();
        }

        public static string GetEyeClopsTimeStamp()
        {
            return EyeClopsManager.Instance.GetLastTimeStamp();
        }

        public static void RequestLastFocusedObject(out string objectName, out Vector3 objectPosition)
        {
            EyeClopsManager.Instance.GetLastCombinedEyeFocusedObject(out  objectName, out objectPosition);
        }

        public static void SetUsedCamera(Camera usedCamera)
        {
            EyeClopsManager.Instance.SetUsedCamera(usedCamera);
        }

        public static void CheckIfEyeTrackFrameworkIsRunning()
        {
            EyeClopsManager.Instance.CheckIfEyeTrackFrameworkIsRunning();
        }
        
    }
}