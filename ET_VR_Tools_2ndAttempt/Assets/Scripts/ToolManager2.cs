using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using TMPro;

public class ToolManager2 : MonoBehaviour
{
    
    private readonly List<ToolController> _tools = new List<ToolController>();
    private int _trial;
    private int[] _toolOrder;
    private List<GameObject> _toolsList;
    private string _tag = "Tool";
    
    //private ToolPresenter toolPresenter = gameObject.AddComponent<ToolPresenter>;
    //private ToolPresenter _toolPresenter = new ToolPresenter(tools);

    private void Awake()
    {
        _toolsList = GameObject.FindGameObjectsWithTag(_tag).ToList();
        foreach(var toolPrefab in _toolsList)
        {
            _tools.Add(toolPrefab.GetComponent<ToolController>());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _trial = 0;
        _toolOrder = new int[] {1, 2};

        //_toolsList = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g=>g.tag==_tag).ToList();
        //Add all tools, which I've tagged as 'Tool'
        

        Debug.Log(_tools.Count+" tools found");
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
            ToolPresenter.INSTANCE.PresentTool(GetNextTool().gameObject);
            if(_trial < 1) _trial++;
        }
        
    }
}
