﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TestTrialManager : MonoBehaviour
{
    private bool _handInCollider = false;
    private Interactable _interactable;
    private bool _nextTrial = false;
    public static TestTrialManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _interactable = this.GetComponent<Interactable>();
    }

    private void OnHandHoverBegin( Hand hand )
    {
        Debug.Log("Hand hover begin");
        if (hand == TestManager.instance.hand)
        {
            _handInCollider = true;
            Debug.Log("Right hand hover");
        }
    }

    private void OnHandHoverEnd(Hand hand)
    {
        _handInCollider = false;
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (_handInCollider)
        {
            if (TestManager.instance.grabPinch.state)
            {
                Debug.Log("NextTrial");
                _nextTrial = true;
            }
        }
    }
    
    public bool GetTriggerValue()
    {
        bool t = _nextTrial;
        ResetTriggerValue();
        return t;
    }
    
    public void ResetTriggerValue()
    {
        _nextTrial = false;
    }

}