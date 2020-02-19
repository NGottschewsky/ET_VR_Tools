using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UIElements;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TestManager : MonoBehaviour
{
    [Header("Experiment components")]
    public CuePresenter cuePresenter;
    public ToolPresenter toolPresenter;
    public TrialManager trialManager;
    
    // make a singleton instance of ToolManager to be able to call RegistrateCurrentUsedTool method etc. 
    public static TestManager instance;
    
    [Header("Tool Models")] 
    [SerializeField] public List<ToolController> _tools; //List of all tool prefabs in diff. orientations and with diff. cues (48 in total)
    [SerializeField] public GameObject spawnerPositionLeft;
    [SerializeField] public GameObject spawnerPositionRight;
    
    // Current trial (up to 144) 
    private int _trial;
    
    private string[] _toolOrder = {"1","2"};
    
    private bool _endOfBlock = false; // set to true after 2 trials
    private bool _endOfTrial = false; // set to true in method where new trial is started
    
    // last used tool is saved so that it can be deactivated before the new tool is activated 
    private ToolController _lastUsedTool;
    
    public SteamVR_Action_Boolean grabPinch; //Grab Pinch is the trigger, select from inspector
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.RightHand; //which controller
    public Hand hand;
    
    
    #region Singelton
    //make ToolManager2 singleton to be able to create 1 instance on which to call its methods
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    #endregion

    void Start()
    {
        _trial = 0;
        _tools[0].cue = "Lift";
        _tools[0].orientation = "Right";
        _tools[1].cue = "Use";
        _tools[1].orientation = "Left";
    }

    private void GetNextTool(out ToolController returnTool)
    {
        returnTool = null;//new ToolController();

        foreach (var toolController in _tools)
        {
            if (toolController.id == _toolOrder[_trial])
            {
                returnTool = toolController;
            }
        }
    }
    void Update()
    {
        if (_trial == _toolOrder.Length)
        {
            _endOfBlock = true; 
        }


        if (TrialEndReached() && !_endOfBlock)  //Input.GetKeyDown(KeyCode.Space) && !_endOfBlock) _trial <= _toolOrder.Length) //!
        {
            GetNextTool(out var internalTool);
            TestTrialManager.instance.ResetTriggerValue();
            
            
            if (internalTool.cue == "Lift")
            {
                ShowMessage(Color.white, "   ", 60);
                StartCoroutine(ShowMessageCoroutine(Color.white, "Lift", 60));
            }
            else if(internalTool.cue == "Use")
            {
                ShowMessage(Color.white, "   ", 60);
                StartCoroutine(ShowMessageCoroutine(Color.white, "Use", 60));

            }
            else
            {
                Debug.Log("Tool Id in neither cue list");
            }
            
            
            if (internalTool.orientation == "Left")
            {
                StartCoroutine(ToolPresenter.INSTANCE.PresentTool(internalTool, "left"));
            }
            else if (internalTool.orientation == "Right")
            {
                StartCoroutine(ToolPresenter.INSTANCE.PresentTool(internalTool, "right"));
            }
            else
            {
                Debug.LogError("tool ID not contained in either list of tools");
            }

            _trial++;
            
        }

        
        if (TrialEndReached()  && _endOfBlock)
        {
            DeactivateLastTool();
            Debug.Log("End of Block.");
            TestTrialManager.instance.ResetTriggerValue();
            ShowMessage(Color.white, "You have finished the test trials.", 30);
        }
        
    }
    
    // shows text after a 1 second delay
    IEnumerator ShowMessageCoroutine(Color32 color, string msg, int fontsize) 
    {
        yield return new WaitForSeconds(1.0f);
        cuePresenter.lableColor = color;
        cuePresenter.font = fontsize;
        cuePresenter.ShowText(msg);
    }
    
    // shows text without a delay 
    public void ShowMessage(Color32 color, string msg, int fontsize)
    {
        cuePresenter.lableColor = color;
        cuePresenter.font = fontsize;
        cuePresenter.ShowText(msg);
    }

    private bool TrialEndReached()
    {
        bool triggerValue = TestTrialManager.instance.GetTriggerValue();
        TestTrialManager.instance.ResetTriggerValue();
        return triggerValue;

        //throw new NotImplementedException();
        //if vr controller held into collider for 5 secs or if it is placed in a snapzone or smth similar
    }

    public void DeactivateLastTool()
    {
        if (_lastUsedTool != null)
        {
            _lastUsedTool.DeactivateThis();
        }
    }
    
    public void RegistrateCurrentUsedTool(ToolController tool)
    {
        _lastUsedTool = tool;
    }


}
