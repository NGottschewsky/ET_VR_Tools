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
    private void Awake()
    {
        if (instanceEyeTrackingManager == null)
            instanceEyeTrackingManager = this;
        TobiiXR.Start(settings);
        //SRanipal_Eye_v2.LaunchEyeCalibration();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
