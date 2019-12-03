using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using TMPro;

public class ToolManager2 : MonoBehaviour
{
    public static ToolManager2 instance;

    [SerializeField] private List<ToolController> _tools;
    [SerializeField] public GameObject spawnerPosition;
    private int _trial;

    private int[] _toolOrder;
    
    private bool _endOfBlock = false;

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
        _toolOrder = new int[] {1, 2}; // Tool Order should be read from CSV Experiment Matrix

        Debug.Log(_tools.Count + " tools found");
    }


    private void GetNextTool(out ToolController returnTool)
    {
        returnTool = new ToolController();
        foreach (var toolController in _tools)
        {
            //try
            //{
            if (toolController.id == _toolOrder[_trial])
            {
                returnTool = toolController;
            }
            //}
            //catch (IndexOutOfRangeException e)
            //{
            //   Debug.Log("End of Block");
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
//        if (EndConditionReached()) //condition that ends the trial
//        {
            /*GetNextTool(out var internalTool);
            ToolPresenter.INSTANCE.PresentTool(internalTool);
            if (_trial < 1) _trial++;*/
//        }
        if (Input.GetKeyDown(KeyCode.Space) && !_endOfBlock) //will be replaced with some controller movement
        {
            GetNextTool(out var internalTool);
            ToolPresenter.INSTANCE.PresentTool(internalTool);
            _trial++;
        }

        if (_trial == (_toolOrder.Length))
        {
            _endOfBlock = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _endOfBlock)
        {
            Debug.Log("End of Block.");
            //Use textMeshPro to make text appear
        }
        
    }

    private bool EndConditionReached()
    {
        throw new NotImplementedException();
        //if vr controller held into collider for 5 secs or if it is placed in a snapzone or smth similar
    }

    public void DeactivateLastTool()
    {
        if (_lastUsedTool != null)
            _lastUsedTool.DeactivateThis();
    }

    public void RegistrateCurrentUsedTool(ToolController tool)
    {
        _lastUsedTool = tool;
    }
}