using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    private List<ToolController> _tools = new List<ToolController>();
    private int _trial;
    // Start is called before the first frame update
    void Start()
    {
        _trial = 0;
        foreach(GameObject toolPrefab in GameObject.FindGameObjectsWithTag("Tool"))
        {
            _tools.Add(toolPrefab.GetComponent<ToolController>());
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
