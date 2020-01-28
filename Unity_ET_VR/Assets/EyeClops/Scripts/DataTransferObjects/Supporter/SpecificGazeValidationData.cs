using EyeClops.Data;
using UnityEngine;
using ViveSR.anipal.Eye;


public struct SpecificGazeValidationData
{
    private Ray _ray;

    public Ray Ray
    {
        get => _ray;
        set => _ray = value;
    }

    private CustomFocusInfo _focusInfo;

    public CustomFocusInfo FocusInfo
    {
        get => _focusInfo;
        set => _focusInfo = value;
    }

    private Vector3 _errorVector;

    public Vector3 ErrorVector
    {
        get => _errorVector;
        set => _errorVector = value;
    }

    private Vector3 _groundTruth;

    public Vector3 GroundTruth
    {
        get => _groundTruth;
        set => _groundTruth = value;
    }

    private float _errorAngle;

    public float ErrorAngle
    {
        get => _errorAngle;
        set => _errorAngle = value;
    }

    public SpecificGazeValidationData(Ray ray, CustomFocusInfo focusInfo, float errorAngle, Vector3 groundTruth,
        Vector3 errorVector)
    {
        _ray = ray;
        _focusInfo = focusInfo;
        _groundTruth = groundTruth;
        _errorVector = errorVector;
        _errorAngle = errorAngle;
    }
}