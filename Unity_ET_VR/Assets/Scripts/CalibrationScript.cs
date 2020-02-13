using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using Valve.VR.InteractionSystem;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalibrationScript : MonoBehaviour
{
    public SteamVR_Input_Sources source = SteamVR_Input_Sources.Any;
    public SteamVR_Action_Boolean startCalibration;
    public Hand hand;
    private Transform _handTransform;
    public GameObject table;
    private Transform _tableTransform;
    private bool _controllerReached = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (hand != null) _handTransform = hand.transform;
        _tableTransform = table.transform;
        var tableTransformPosition = _tableTransform.position;
        tableTransformPosition.y = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCalibration.state)
        {
            Debug.Log(table.transform.lossyScale.z);
        }
        //var tableTransformLocalScale = _tableTransform.localScale;
        //tableTransformLocalScale.z += 0.1f;
        
        /*if (!_controllerReached)
        {
            var tableTransformLocalScale = _tableTransform.localScale;
            tableTransformLocalScale.z += 0.1f;
        }*/
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MyControllerTag"))
        {
            _controllerReached = true;
        }
    }
}
