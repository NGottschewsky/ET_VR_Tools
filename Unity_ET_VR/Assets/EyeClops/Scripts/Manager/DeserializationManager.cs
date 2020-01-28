using System.Collections.Generic;
using EyeClops.Data;
using EyeClops.DataLayer;
using UnityEngine;

namespace EyeClops.Manager
{
    public class DeserializationManager : MonoBehaviour
    {
        #region Singelton

        public static DeserializationManager Instance;

        private string _storedFolder;

//        private List<List<EyeTrackingValidationData>> _deserializedValidationData;
//        private List<List<EyeTrackingData>> _deserializedTrackingData;
        private List<DeserializedDataSet> _deserializedData;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        #endregion

        private void Start()
        {
            ResetDeserializedData();
        }

        public void SetStoredFolder(string selectedFolder)
        {
            _storedFolder = selectedFolder;
        }

        public void DeserializeSingleDataSet(string folderPath, string filePrefix, string fileEnding)
        {
            DataIOManager.Instance.ReadEyeTrackingData(folderPath, filePrefix, fileEnding,
                out List<EyeClopsValidationData> validationData,
                out List<EyeClopsData> trackingData);
            _deserializedData.Add(new DeserializedDataSet(filePrefix, validationData, trackingData));
        }

        public void ResetDeserializedData()
        {
            _deserializedData = new List<DeserializedDataSet>();
        }

        public void GenerateIdentifierAndFileEndingMap(string folderPath,
            out Dictionary<string, List<string>> fileIdAndTypeMap)
        {
            DataIOConnector.GenerateIdentifierAndFileEndingMap(folderPath, out fileIdAndTypeMap);
        }
    }
}