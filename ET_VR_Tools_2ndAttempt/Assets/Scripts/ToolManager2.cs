using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ToolManager2 : MonoBehaviour
{
    
    private readonly List<ToolController> _tools = new List<ToolController>();
    private int _trial;
    private string[] _toolOrder;

    //private ToolPresenter toolPresenter = gameObject.AddComponent<ToolPresenter>;
    //private ToolPresenter _toolPresenter = new ToolPresenter(tools);
    
    // Start is called before the first frame update
    void Start()
    {
        _trial = 0;
        _toolOrder = new string[] {"1", "2"};
        
        //Add all tools, which I've tagged as 'Tool'
        foreach(GameObject toolPrefab in GameObject.FindGameObjectsWithTag("Tool"))
        {
            _tools.Add(toolPrefab.GetComponent<ToolController>());
        }
    }
    
    
    public ToolController GetNextTool()
    {
        ToolController temp = null;
        foreach (var tool in _tools)
        {
            if (tool.id.Equals(_toolOrder[_trial]))
            {
                temp = tool;
                break; 
            }
        }

        if (temp == null)
        {
            Debug.LogError("Next toolID from _toolOrder does not match any ID in List _tools.");
        }
        return temp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToolPresenter.INSTANCE.PresentTool(GetNextTool().GetComponent<GameObject>());
        }
        
    }
}
