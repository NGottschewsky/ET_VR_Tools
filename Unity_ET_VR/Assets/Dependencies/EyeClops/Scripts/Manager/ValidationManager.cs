using System.Collections.Generic;
using EyeClops.Controller;
using EyeClops.Data;
using EyeClops.DataLayer.DeSerializer;
using UnityEngine;
using UnityEngine.UI;

namespace EyeClops.Manager
{
    public class ValidationManager : MonoBehaviour
    {
        #region Singleton

        public static ValidationManager instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        #endregion

        [SerializeField] private Canvas _validationCanvas;
        [SerializeField] private List<ValidationAtGazeController> _validationPoints;
        [SerializeField] private float _endOfValidationTime = 5;
        [SerializeField] private float _shrinkingFactor = 0.05f;
        [SerializeField] private RawImage _validationImage;


        private int _cullingMaskLayer;

        private List<EyeClopsValidationData> _validationDatas;

        private int _validationCounter;

        // Start is called before the first frame update
        void Start()
        {
            _validationCanvas.worldCamera = EyeClopsManager.Instance.GetUsedCamera();
            _validationDatas = new List<EyeClopsValidationData>();
            _cullingMaskLayer = _validationCanvas.worldCamera.eventMask;
            _validationCanvas.gameObject.SetActive(false);
        }

        public void StartValidation()
        {
//            ActivateAllValidationPoints();
            _validationCanvas.gameObject.SetActive(true);
            _validationCounter++;
            DeactivateAllUnuesedLayer();
            RefreshAllValidationPoints();
            ActivateNextValidationPoint();
        }

        private void UpdateValidationResults()
        {
            List<EyeClopsValidationData> lastValidationData = GetLastValidationData();
            EyeClopsManager.Instance.UpdateShowValidationResults(lastValidationData);
//        throw new NotImplementedException("Should update the validation data into the eye tracking Controller, which controls the UI");
        }

        /// <summary>
        /// Deactivate All other layer and show just the UI-Layer to present only the Validationpoints
        /// </summary>
        private void DeactivateAllUnuesedLayer()
        {
            Debug.Log("1. " + _validationCanvas);
            Debug.Log("2. " + _validationCanvas.worldCamera);
            Debug.Log("3. " + _validationCanvas.worldCamera.cullingMask);
            _validationCanvas.worldCamera.cullingMask = (1 << LayerMask.NameToLayer("UI"));
        }

        private void RefreshAllValidationPoints()
        {
            foreach (ValidationAtGazeController validationAtGazeController in _validationPoints)
            {
                validationAtGazeController.gameObject.SetActive(true);
                validationAtGazeController.RefreshStatus();
            }
        }

        private void ActivateNextValidationPoint()
        {
            ValidationAtGazeController helpActivationFunction = RandomValidationPoint();
            if (helpActivationFunction != null)
            {
                ActivateSpecificValidationPoint(helpActivationFunction);
            }
            else
            {
                FinishValidation();
            }
        }

        private void FinishValidation()
        {
            //Reset to the old CullingMaskLayer
            UpdateValidationResults();
            _validationCanvas.worldCamera.cullingMask = _cullingMaskLayer;
            _validationCanvas.gameObject.SetActive(false);
        }

        private ValidationAtGazeController RandomValidationPoint()
        {
            foreach (ValidationAtGazeController validationPoint in _validationPoints)
            {
                if (validationPoint.IsUnused())
                {
                    validationPoint.IsNowUsed();
                    return validationPoint;
                }
            }

            return null;
        }

        private void ActivateAllValidationPoints()
        {
            foreach (ValidationAtGazeController validationPoint in _validationPoints)
            {
                Debug.Log(validationPoint);
                ActivateSpecificValidationPoint(validationPoint);
            }
        }

        private void ActivateSpecificValidationPoint(ValidationAtGazeController validationPoint)
        {
            validationPoint.ActivateThisValidationPoint();
        }

        public void AddValidationData(ValidationAtGazeController validationAtGazeController)
        {
            EyeClopsValidationData createdValidationData =
                new EyeClopsValidationData(validationAtGazeController, Time.time, _validationCounter,
                    validationAtGazeController.GetGazeValidation());

            _validationDatas.Add(createdValidationData);
        }

        public float GetEndOfValidationTime()
        {
            return _endOfValidationTime;
        }

        public float GetShrinkingFactor()
        {
            return 1 - _shrinkingFactor;
        }

        public void ThisPointIsFinished()
        {
            ActivateNextValidationPoint();
        }


        public List<EyeClopsValidationData> GetLastValidationData()
        {
            List<EyeClopsValidationData> returnData = new List<EyeClopsValidationData>();

            foreach (EyeClopsValidationData eyeTrackingValidationData in _validationDatas)
            {
                if (eyeTrackingValidationData.GetValidationTrial() == _validationCounter)
                {
                    returnData.Add(eyeTrackingValidationData);
                }
            }

            return returnData;
        }

        public List<EyeClopsValidationData> GetValidationDates()
        {
            return _validationDatas;
        }

        public bool CheckIsLegalValidationPoint(string transformName)
        {
            foreach (ValidationAtGazeController validationAtGazeController in _validationPoints)
            {
                if (validationAtGazeController.transform.name.Equals(transformName))
                {
                    return true;
                }
            }

            return false;
        }

        public Dictionary<int, Dictionary<string, List<GazeValidationData>>> GetGazeValidationData()
        {
            Dictionary<int, Dictionary<string, List<GazeValidationData>>> outPut =
                new Dictionary<int, Dictionary<string, List<GazeValidationData>>>();


            int highestTryNumber = HighestTryNumber();
            for (int i = 1; i <= highestTryNumber; i++)
            {
                Dictionary<string, List<GazeValidationData>> innerDictionary =
                    new Dictionary<string, List<GazeValidationData>>();
                List<EyeClopsValidationData> eyeTrackingValidationData =
                    _validationDatas.FindAll(data => data.GetValidationTrial() == i);
                foreach (EyeClopsValidationData validationData in eyeTrackingValidationData)
                {
                    innerDictionary.Add(validationData.GetValidationPoint(), validationData.GetGazeValidation());
                }

                outPut.Add(i, innerDictionary);
            }

            return outPut;
        }

        private int HighestTryNumber()
        {
            var number = int.MinValue;
            foreach (EyeClopsValidationData data in _validationDatas)
            {
                if (data.GetValidationTrial() > number)
                    number = data.GetValidationTrial();
            }

            return number;
        }
    }
}