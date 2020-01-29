using System;
using System.Collections;
using System.Collections.Generic;
using EyeClops.Data;
using EyeClops.DataLayer.DeSerializer;
using EyeClops.Manager;
using Tobii.G2OM;
using UnityEngine;
using UnityEngine.UI;
using ViveSR.anipal.Eye;

namespace EyeClops.Controller
{
    public class ValidationAtGazeController : MonoBehaviour, IGazeFocusable
    {
        public Color HighlightColor = Color.red;
        public float AnimationTime = 0.1f;

        private Graphic _graphic;
        private Color _originalColor;
        private Color _targetColor;

        private bool _isUnused = true;

        private bool _validationStarted;
        private bool _validationGazeWaitForStart = true;
        private float _endTime;
        private float _shrikingFactor;
        private bool _isFocused;
        private Vector3 _originScale;
        private List<GazeValidationData> _gazeValidationData;

        [SerializeField] private Color _rayColor = Color.black;

        //The method of the "IGazeFocusable" interface, which will be called when this object receives or loses focus
        public void GazeFocusChanged(bool hasFocus)
        {
            //If this object received focus, fade the object's color to highlight color
            if (hasFocus)
            {
                _isFocused = true;
                if (!_validationStarted)
                {
                    _validationStarted = true;
                }

                _endTime = Time.time + ValidationManager.instance.GetEndOfValidationTime();

                _targetColor = HighlightColor;
            }
            //If this object lost focus, fade the object's color to it's original color
            else
            {
                _isFocused = false;
                _targetColor = _originalColor;
            }
        }

        private void Awake()
        {
            _originScale = gameObject.transform.localScale;
            _graphic = GetComponent<Graphic>();
        }

        private void OnEnable()
        {
            _originalColor = _graphic.color;
            _targetColor = _originalColor;
            _gazeValidationData = new List<GazeValidationData>();
        }

        private void Start()
        {
            _shrikingFactor = ValidationManager.instance.GetShrinkingFactor();
        }

        private void Update()
        {
            //This lerp will fade the color of the object
            _graphic.color =
                Color.Lerp(_graphic.color, _targetColor, Time.deltaTime * (1 / AnimationTime));
            if (_isFocused)
            {
                gameObject.transform.localScale = gameObject.transform.localScale * _shrikingFactor;
            }

            if (_validationStarted && _validationGazeWaitForStart)
            {
                StartGazeValidation();
            }

            if (_validationStarted && _endTime < Time.time)
            {
                EndValidation();
            }
        }

        private void StartGazeValidation()
        {
            _validationGazeWaitForStart = false;
            StartCoroutine(StartGazeValidationRoutine());
        }

        private IEnumerator StartGazeValidationRoutine()
        {
            while (true)
            {
                _gazeValidationData.Add(new GazeValidationData
                {
                    LeftEyeGazeValidationData = GenerateSpecificGazeValidation(GazeIndex.LEFT),
                    RightEyeGazeValidationData = GenerateSpecificGazeValidation(GazeIndex.RIGHT),
                    CombinedEyeGazeValidationData = GenerateSpecificGazeValidation(GazeIndex.COMBINE)
                });
                yield return new WaitForSeconds(EyeClopsManager.Instance.GetHertzValue());
            }
        }

        private SpecificGazeValidationData GenerateSpecificGazeValidation(GazeIndex gazeIndex)
        {
            Ray ray = new Ray();
            SRanipal_Eye.GetGazeRay(gazeIndex, out ray);
            SRanipal_Eye.Focus(gazeIndex, out ray, out var focusInfo);

            Vector3 groundTruth = gameObject.transform.position - ray.origin;
            Vector3 errorVector = focusInfo.point - ray.origin;
            float errorAngle = Vector3.Angle(groundTruth, errorVector);

            //TODO: Check the RayCastHit -> why is it not used?
            Physics.Raycast(ray, out _, float.PositiveInfinity);
            return new SpecificGazeValidationData(ray, new CustomFocusInfo(focusInfo), errorAngle, groundTruth,
                errorVector);
        }

        private Ray GenerateGazeRayData(GazeIndex gazeIndex)
        {
            SRanipal_Eye.GetGazeRay(gazeIndex, out var returnRay);
            return returnRay;
        }


        private void EndValidation()
        {
            StopCoroutine(StartGazeValidationRoutine());
            ValidationManager.instance.AddValidationData(this);
            ValidationManager.instance.ThisPointIsFinished();
            gameObject.SetActive(false);
        }

        public void ActivateThisValidationPoint()
        {
            gameObject.transform.localScale = _originScale;
            gameObject.SetActive(true);
        }

        public void IsNowUsed()
        {
            _isUnused = false;
        }

        public bool IsUnused()
        {
            return _isUnused;
        }

        public void RefreshStatus()
        {
            _targetColor = _originalColor;
            _validationStarted = false;
            _isUnused = true;
            _endTime = 0;
            gameObject.SetActive(false);
        }

        public List<GazeValidationData> GetGazeValidation()
        {
            return _gazeValidationData;
        }
    }
}