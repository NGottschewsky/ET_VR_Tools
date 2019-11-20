using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ToolPresenter: MonoBehaviour
{
    
    private Vector3 position;
    private Quaternion rotation;
    private bool _isPresent;

    
    public static readonly ToolPresenter INSTANCE = new ToolPresenter();

    private ToolPresenter()
    {
    }
    
    public static ToolPresenter Instance
    {
        get { return INSTANCE; }
    }


    private void Start()
    {
        position = new Vector3(0.5f, 1.549906f,0.0f);
        rotation = new Quaternion(0,0,0,0);
        _isPresent = false;
    }


    public void PresentTool(GameObject tool)
    {
        GameObject currentlyPresentTool = null;
        GameObject toolInstance;
        
        if (!_isPresent)
        {
            // add position and rotation to Instantiated tool
            toolInstance = Instantiate(tool, position, rotation).GetComponent<GameObject>();
            _isPresent = true;
            //save GameObject that is currently on the table to be able to destroy it in the else statement and present 
            //next one
            currentlyPresentTool = tool;
        }
        else
        {
            //destroy game object and spawn new one
            Destroy(currentlyPresentTool);
            toolInstance = Instantiate(tool, position, rotation).GetComponent<GameObject>();
        }
        currentlyPresentTool = tool;
        _isPresent = true;

    }
}


