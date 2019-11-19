using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ToolManager2 : MonoBehaviour
{
    
    private List<ToolController> _tools = new List<ToolController>();
    private int _trial;
    public GameObject[] tools;

    //private ToolPresenter toolPresenter = gameObject.AddComponent<ToolPresenter>;
    //private ToolPresenter _toolPresenter = new ToolPresenter(tools);
    
    // Start is called before the first frame update
    void Start()
    {
        _trial = 0;
        
        //Add all tools, which I've tagged as 'Tool'
        foreach(GameObject toolPrefab in GameObject.FindGameObjectsWithTag("Tool"))
        {
            _tools.Add(toolPrefab.GetComponent<ToolController>());
        }
    }
    
    
    public void GetNextTool(out ToolController nextTool)
    {
        foreach (var tool in _tools)
        {
            if (tool.id.Equals(toolOrder[_trial]))
            {
                nextTool = tool;
            }
        }
// Das ist noch nicht so das wahre hier
        nextTool = null;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var tool in tools)
        {
            ToolPresenter.INSTANCE.presentTool(tool);
        }
    }
}
