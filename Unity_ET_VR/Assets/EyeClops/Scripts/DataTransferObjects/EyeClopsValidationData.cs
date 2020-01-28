using System;
using System.Collections.Generic;
using EyeClops.Analytical;
using EyeClops.Controller;
using EyeClops.DataLayer.DeSerializer;
using EyeClops.Internals;
using UnityEngine;

namespace EyeClops.Data
{
    public class EyeClopsValidationData
    {
        private readonly String _pointName;
        private readonly Vector3 _lastPointScale;
        private readonly float _measuringTime;
        private readonly int _validationTrial;
        private  List<GazeValidationData> _gazeValidationData;
        private Dictionary<EyeType, Dictionary<StatisticalDataType, float>> _statisticalData;

        public EyeClopsValidationData()
        {
        }

        public EyeClopsValidationData(ValidationAtGazeController validationAtGaze, float measuringTime,
            int validationTrial,
            List<GazeValidationData> gazeValidation)
        {
            _pointName = validationAtGaze.gameObject.name;
            _lastPointScale = validationAtGaze.gameObject.transform.localScale;
            _measuringTime = measuringTime;
            _validationTrial = validationTrial;
            _gazeValidationData = gazeValidation;
            SetUpStatisticalDataOfEachGazeValidation(out _statisticalData);
        }

        public EyeClopsValidationData(string pointName, Vector3 lastPointScale, float measuringTime,
            int validationTrial,
            List<GazeValidationData> gazeValidationData)
        {
            _pointName = pointName;
            _lastPointScale = lastPointScale;
            _measuringTime = measuringTime;
            _validationTrial = validationTrial;
            _gazeValidationData = gazeValidationData;
            if (_gazeValidationData != null)
            {
                SetUpStatisticalDataOfEachGazeValidation(out _statisticalData);
            }
        }

        private void SetUpStatisticalDataOfEachGazeValidation(
            out Dictionary<EyeType, Dictionary<StatisticalDataType, float>> statisticalData)
        {
            statisticalData = new Dictionary<EyeType, Dictionary<StatisticalDataType, float>>
            {
                {EyeType.LeftEye, EyeClopsAnalyser.CalculateStatisticalEyeData(GetGazeDataFromLeftEye())},
                {EyeType.RightEye, EyeClopsAnalyser.CalculateStatisticalEyeData(GetGazeDataFromRightEye())},
                {EyeType.CombinedEye, EyeClopsAnalyser.CalculateStatisticalEyeData(GetGazeDataFromCombinedEye())}
            };
        }

        public int GetValidationTrial()
        {
            return _validationTrial;
        }

        private List<SpecificGazeValidationData> GetGazeDataFromCombinedEye()
        {
            List<SpecificGazeValidationData> returnList = new List<SpecificGazeValidationData>();

            foreach (GazeValidationData gazeValidationData in _gazeValidationData)
            {
                returnList.Add(gazeValidationData.CombinedEyeGazeValidationData);
            }

            return returnList;
        }

        private List<SpecificGazeValidationData> GetGazeDataFromRightEye()
        {
            List<SpecificGazeValidationData> returnList = new List<SpecificGazeValidationData>();

            foreach (GazeValidationData gazeValidationData in _gazeValidationData)
            {
                returnList.Add(gazeValidationData.RightEyeGazeValidationData);
            }

            return returnList;
        }

        private List<SpecificGazeValidationData> GetGazeDataFromLeftEye()
        {
            List<SpecificGazeValidationData> returnList = new List<SpecificGazeValidationData>();

            foreach (GazeValidationData gazeValidationData in _gazeValidationData)
            {
                returnList.Add(gazeValidationData.LeftEyeGazeValidationData);
            }

            return returnList;
        }

        public List<GazeValidationData> GetGazeValidation()
        {
            return _gazeValidationData;
        }

        public String GetValidationPoint()
        {
            return _pointName;
        }

        public Vector3 GetLastPointScale()
        {
            return _lastPointScale;
        }

        public float GetMeasuringTime()
        {
            return _measuringTime;
        }

        public Dictionary<EyeType, Dictionary<StatisticalDataType, float>> GetStatisticalDataOfEachGazeValidation()
        {
            if (_statisticalData == null && _gazeValidationData != null)
            {
                SetUpStatisticalDataOfEachGazeValidation(out _statisticalData);
            }

            return _statisticalData;
        }

        public void ReadIntoGazeValidationData(List<GazeValidationData> gazeValidationData)
        {
            _gazeValidationData = gazeValidationData;
        }
    }
}