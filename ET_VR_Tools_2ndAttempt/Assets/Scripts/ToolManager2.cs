using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

public class ToolManager2 : MonoBehaviour
{
    
    private readonly List<ToolController> _tools = new List<ToolController>();
    private int _trial;
    private int[] _toolOrder;
    private string _tag = "Tool";
    private List<GameObject> _toolsList;
    
    //private ToolPresenter toolPresenter = gameObject.AddComponent<ToolPresenter>;
    //private ToolPresenter _toolPresenter = new ToolPresenter(tools);
    
    // Start is called before the first frame update
    void Start()
    {
        _trial = 0;
        _toolOrder = new int[] {1, 2};

        _toolsList = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g=>g.tag==_tag).ToList();
        //Add all tools, which I've tagged as 'Tool'
        foreach(var toolPrefab in _toolsList)
        {
            _tools.Add(toolPrefab.GetComponent<ToolController>());
        }

        Debug.Log(_tools.Count);
    }


    private ToolController GetNextTool()
    {
        int temp = new int();
        for(var i = _tools.Count - 1; i >= 0; i--)
        {
            Debug.Log("Hallo");
            if (_tools[i].id.Equals(_toolOrder[_trial]))
            {
                Debug.Log("Tool number "+ _toolOrder[_trial]+" fits");
                temp = i;
                break; 
            }
        }
        return _tools[temp];
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_toolOrder[_trial]);
        Debug.Log(GetNextTool().ToString());
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToolPresenter.INSTANCE.PresentTool(GetNextTool().GetComponent<GameObject>());
        }
        
    }
}
