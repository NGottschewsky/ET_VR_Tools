using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Valve.VR.InteractionSystem;

public class TrialManager : MonoBehaviour
{
    public GameObject sphereTrigger;
    public Transform spherePosition;
    private bool _isTriggerEntered;
    private bool _nextTrial = false;
    private bool _timerBlocked = false;
    private float _waitTime = 2.0f;
    public static TrialManager colliderInstance;
    
    #region Singelton
    //make ToolManager2 singleton to be able to create 1 instance on which to call its methods
    private void Awake()
    {
        if (colliderInstance == null)
            colliderInstance = this;
    }

    #endregion
    
    private void Update()
    {
        if (_isTriggerEntered && !_timerBlocked)
        {
            _waitTime -= Time.deltaTime;

            if (_waitTime < 0)
            {
                _waitTime = 0;
            }
        }
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MyControllerTag"))
        {
            Debug.Log("Trigger Entered by a Controller");
            _isTriggerEntered = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MyControllerTag") && _isTriggerEntered)
        {
            // This needs to be tested, but the Vive and the controllers are gone
            // okey turns out this doesn't work
            /*if (ToolManager2.instance.grabPinch.state == true)
            {
                _nextTrial = true;
                _timerBlocked = true;
            }*/
            //Debug.Log("Countdown not yet done");
            if (_waitTime <= 0)
            {
                Debug.Log("Lange genug im Trigger gewesen");
                _nextTrial = true;
                _timerBlocked = true;
                sphereTrigger.GetComponent<Throwable>().enabled = false;
                sphereTrigger.transform.position = spherePosition.position;
                StartCoroutine(Reset());
            }
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1.0f);
        _isTriggerEntered = false;
        _nextTrial = false;
        _timerBlocked = false;
        _waitTime = 2.0f;
        StartCoroutine(ActivateThrowable());
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MyControllerTag"))
        {
            Debug.Log("Trigger Exited by a Controller");
            _isTriggerEntered = false;
            _nextTrial = false;
            _timerBlocked = false;
            _waitTime = 2.0f;
        }
    }*/
    
    public void ResetTriggerValue()
    {
        _nextTrial = false;
        _waitTime = 2.0f;
    }

    public bool GetTriggerValue()
    {
        return _nextTrial;
    }

    IEnumerator ActivateThrowable()
    {
        yield return new WaitForSeconds(2.0f);
        sphereTrigger.GetComponent<Throwable>().enabled = true;
    }

}
