using System;
using System.Collections;
using System.Collections.Generic;
using Tobii.XR;
using UnityEngine;
using ViveSR;
using ViveSR.anipal;
using ViveSR.anipal.Eye;

public class EyeTrackingManager : MonoBehaviour
{
    public static EyeTrackingManager instanceEyeTrackingManager;
    public TobiiXR_Settings settings;

    [Space] [Header("Reference to the ETGValidation Script")]
    public ETGValidation validator;

    [Space] [Header("Key bindings")] public KeyCode callibrationButton;
    public KeyCode ValidationButton;

    private void Awake()
    {
        if (instanceEyeTrackingManager == null)
            instanceEyeTrackingManager = this;
        if (TobiiXR.Start(settings))
        {
            Debug.Log("starting succesful");
        }


//        if (SRanipal_Eye_v2.LaunchEyeCalibration())
//        {
//            Debug.Log("calibration succesful");
//        }
//
//        if (validator != null)
//        {
//            validator.StartValidation();
//        }
//        else
//        {
//            Debug.LogError("ETGValidation field is not setup.");
//        }
    }



    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(callibrationButton))
        {
            if (SRanipal_Eye_v2.LaunchEyeCalibration())
            {
                Debug.Log("calibration succesful");
            }
        }

        if (Input.GetKeyDown(ValidationButton))
        {
            //enable sphere
            if (validator != null)
            {
                validator.StartValidation();
            }
            else
            {
                Debug.LogError("ETGValidation field is not setup.");
            }
        }
        
    }
}