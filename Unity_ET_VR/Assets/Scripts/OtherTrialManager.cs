using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class OtherTrialManager : MonoBehaviour
{
    private bool _handInCollider = false;
    private Interactable _interactable;
    private bool _nextTrial = false;
    public static OtherTrialManager instance;

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
        if (hand == ToolManager2.instance.hand)
        {
            _handInCollider = true;
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
            if (ToolManager2.instance.grabPinch.state)
            {
                
            }
        }
    }

}
