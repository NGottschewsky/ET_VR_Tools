using System;
using System.Collections.Generic;
using EyeClops.Data;
using EyeClops.Internals;
using EyeClops.Manager;
using UnityEngine;
using UnityEngine.UI;


namespace EyeClops.Controller
{
    public class EyeClopsGuiController : MonoBehaviour
    {
        [SerializeField] private Text calibrationStatus;

        [SerializeField] private GameObject validationInfoField;
        [SerializeField] private Text validationDataArea;

        private string _validationInfoText;
        private const int RoundDigits = 4;

        private string _calibrationStatus = "Not yet calibrated";
        private Color _calibrationColor = Color.white;

        public void StartCalibration()
        {
            EyeClopsManager.Instance.StartCalibration();
        }

        public void StartValidation()
        {
            EyeClopsManager.Instance.StartValidation();
        }

        public void PauseContinueEyeTracking(Text buttonText)
        {
            EyeClopsManager.Instance.PauseContinueEyeTracking(buttonText);
        }

        public void StartStoringData()
        {
            EyeClopsManager.Instance.SaveEyeTrackingData(null);
        }

        public void ChangeVisibilityOfValidationData(bool toggleStatus)
        {
            validationInfoField.SetActive(toggleStatus);
        }

        public void UpdateValidationPointData(List<EyeClopsValidationData> lastValidationData)
        {
            _validationInfoText = "";
            foreach (EyeClopsValidationData eyeTrackValiData in lastValidationData)
            {
                _validationInfoText += eyeTrackValiData.GetValidationPoint() + ": " + Environment.NewLine +
                                       Math.Round(eyeTrackValiData.GetLastPointScale().x * Math.PI, RoundDigits) +
                                       Environment.NewLine;
            }

            _validationInfoText +=
                "Degree: " + Environment.NewLine + CalculateMeanDegreeOfValidationData(lastValidationData);
            validationDataArea.text = _validationInfoText;
        }

        private double CalculateMeanDegreeOfValidationData(List<EyeClopsValidationData> lastValidationData)
        {
            double summOfMeans = 0;
            int numberOfmeans = 0;
            foreach (EyeClopsValidationData validationData in lastValidationData)
            {
                Dictionary<StatisticalDataType, float> dictionary =
                    validationData.GetStatisticalDataOfEachGazeValidation()[EyeType.CombinedEye];
                float mean = dictionary[StatisticalDataType.Mean];
                summOfMeans += mean;
                numberOfmeans++;
            }

            return numberOfmeans > 0 ? Math.Round((summOfMeans / numberOfmeans), RoundDigits) : 0;
        }

        public void UpdateCalibrationStatusInfo(bool launchEyeCalibration)
        {
            if (launchEyeCalibration)
            {
                _calibrationStatus = "SUCCESSFUL";
                _calibrationColor = Color.green;
            }
            else
            {
                _calibrationStatus = "FAILED";
                _calibrationColor = Color.red;
            }

            calibrationStatus.text = _calibrationStatus;
            calibrationStatus.color = _calibrationColor;
        }

        public void OpenEyeClopsMenu(GameObject eyeClopsOption)
        {
            eyeClopsOption.SetActive(!eyeClopsOption.activeInHierarchy);
        }
    }
}