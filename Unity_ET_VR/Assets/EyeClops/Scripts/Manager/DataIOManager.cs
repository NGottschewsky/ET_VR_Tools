using System;
using System.Collections.Generic;
using EyeClops.Data;
using EyeClops.DataLayer;
using EyeClops.DataLayer.DeSerializer;
using EyeClops.Internals;
using UnityEngine;

namespace EyeClops.Manager
{
    public class DataIOManager : MonoBehaviour
    {
        public static DataIOManager Instance;

        #region Singelton

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        #endregion

        public void SaveEyeTrackingData()
        {
            SaveEyeTrackingData(GetDefaultPrefix());
        }

        public void SaveEyeTrackingData(string filPrefix)
        {
            if (EyeClopsManager.Instance.StoreDataAsCsvFile())
                SaveEyeTrackingDataInCsv(filPrefix);
            if (EyeClopsManager.Instance.StoreDataAsBinaryFile())
                SaveEyeTrackingDataInBinary(filPrefix);
        }


        private void SaveEyeTrackingDataInCsv(string filePrefix)
        {
            DataIOConnector.SaveAllDataInCsv(
                EyeClopsManager.Instance.GetValidationData(),
                EyeClopsManager.Instance.GetGazeValidationData(),
                EyeClopsManager.Instance.GetEyeTrackerData(),
                EyeClopsManager.Instance.GetFileStoringPath(), filePrefix);
        }

        private void SaveEyeTrackingDataInBinary(string filePrefix)
        {
            DataIOConnector.SaveAllDataInBinary(
                EyeClopsManager.Instance.GetValidationData(),
                EyeClopsManager.Instance.GetGazeValidationData(),
                EyeClopsManager.Instance.GetEyeTrackerData(),
                EyeClopsManager.Instance.GetFileStoringPath(), filePrefix);
        }


        private void ReadEyeTrackingDataFromCsv(string filePath, string fileNamePrefix,
            out List<EyeClopsValidationData> validationData,
            out List<EyeClopsData> trackingData)
        {
            validationData = new List<EyeClopsValidationData>();
            trackingData = new List<EyeClopsData>();
            Dictionary<int, Dictionary<string, List<GazeValidationData>>> allDataOverAllTrails =
                new Dictionary<int, Dictionary<string, List<GazeValidationData>>>();
            DataIOConnector.ReadValidationDataFromCsv(filePath, fileNamePrefix, ref validationData);
            DataIOConnector.ReadGazeValidationDataFromCsv(filePath, fileNamePrefix, ref allDataOverAllTrails);
            DataIOConnector.ReadEyeTrackingDataFromCsv(filePath, fileNamePrefix, ref trackingData);
            CombineValidationAndGazeValidationData(allDataOverAllTrails, ref validationData);
        }

        private void ReadEyeTrackingDataFromBinary(string folderPath, string filePrefix,
            out List<EyeClopsValidationData> eyeTrackingValidationData, out List<EyeClopsData> eyeTrackingData)
        {
            throw new NotImplementedException("This Method has to be designed like the csv reading method");
        }

        private void CombineValidationAndGazeValidationData(
            Dictionary<int, Dictionary<string, List<GazeValidationData>>> allDataOverAllTrails,
            ref List<EyeClopsValidationData> validationData)
        {
            foreach (EyeClopsValidationData data in validationData)
            {
                data.ReadIntoGazeValidationData(
                    allDataOverAllTrails[data.GetValidationTrial()][data.GetValidationPoint()]);
            }
        }

        public void ReadEyeTrackingData(string folderPath, string filePrefix, string fileEnding,
            out List<EyeClopsValidationData> eyeTrackingValidationData, out List<EyeClopsData> eyeTrackingData)
        {
            eyeTrackingValidationData = new List<EyeClopsValidationData>();
            eyeTrackingData = new List<EyeClopsData>();
            if (FileEndings.IsValidClassEnding(fileEnding))
            {
                switch (fileEnding)
                {
                    case FileEndings.Csv:
                        ReadEyeTrackingDataFromCsv(folderPath, filePrefix, out eyeTrackingValidationData,
                            out eyeTrackingData);
                        break;
                    case FileEndings.Binary:
                        ReadEyeTrackingDataFromBinary(folderPath, filePrefix, out eyeTrackingValidationData,
                            out eyeTrackingData);
                        break;
                }
            }
        }

        public string GetDefaultPrefix()
        {
            return DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "_" +
                   DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second;
        }
    }
}