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
    
    private string[] _toolOrder = new string[]{"1","2"};
    
    private bool _endOfBlock = false; // set to true after 2 trials
    private bool _endOfTrial = false; // set to true in method where new trial is started
    
    // last used tool is saved so that it can be deactivated before the new tool is activated 
    private ToolController _lastUsedTool;
    
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
        returnTool = new ToolController();

        foreach (var toolController in _tools)
        {
            /*if (_trial >= _tools.Count)
            {
                if (toolController.id == _toolOrder[_trial])
                {
                    returnTool = toolController;
                }
            }
            else
            {
                return;
            }*/
            if (toolController.id == _toolOrder[_trial])
            {
                returnTool = toolController;
            }
        }
    }
    void Update()
    {

        if (TrialEndReached() && !_endOfBlock)  //Input.GetKeyDown(KeyCode.Space) && !_endOfBlock)
        {
            GetNextTool(out var internalTool);
            TrialManager.colliderInstance.ResetTriggerValue();
            
            
            if (internalTool.cue == "Lift")
            {
                ShowMessage(Color.white, "   ");
                StartCoroutine(ShowMessageCoroutine(Color.white, "Lift"));
            }
            else if(internalTool.cue == "Use")
            {
                ShowMessage(Color.white, "   ");
                StartCoroutine(ShowMessageCoroutine(Color.white, "Use"));

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

        if (_trial > _toolOrder.Length)
        {
            _endOfBlock = true; 
            ShowMessage(Color.white, "You have finished the test trials.");
        }

        if (TrialEndReached()  && _endOfBlock)
        {
            Debug.Log("End of Block.");
            TrialManager.colliderInstance.ResetTriggerValue();
            // Start second block 
        }
        
    }
    
    // shows text after a 1 second delay
    IEnumerator ShowMessageCoroutine(Color32 color, string msg) 
    {
        yield return new WaitForSeconds(1.0f);
        cuePresenter.lableColor = color;
        cuePresenter.ShowText(msg);
    }
    
    // shows text without a delay 
    public void ShowMessage(Color32 color, string msg)
    {
        cuePresenter.lableColor = color;
        cuePresenter.ShowText(msg);
    }

    private bool TrialEndReached()
    {
        return TrialManager.colliderInstance.GetTriggerValue();
        
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
