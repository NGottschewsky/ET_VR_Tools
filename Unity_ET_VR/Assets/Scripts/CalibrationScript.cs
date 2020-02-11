using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using Valve.VR.InteractionSystem;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CalibrationScript : MonoBehaviour
{
    public Hand hand;
    private Transform _handTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        if (hand != null) _handTransform = hand.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
