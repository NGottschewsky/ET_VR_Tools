using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Serialization;

public class ToolController : MonoBehaviour
{
    //ID to find each tool by, corresponding to the numbers in the experiment matrix
    //public int id;

    public string id;
    public string name;
    
    [HideInInspector]
    public string orientation;
    [HideInInspector]
    public string cue;

    
    //Deactivate the currently presented tool
    public void DeactivateThis()
    {
        gameObject.SetActive(false);
    }

    //activates the tool that should be seen during the next trial
    public void ActivateThis(Vector3 position, Quaternion rotation)
    {
        gameObject.SetActive(true);
        var transform1 = transform;
        transform1.position = position;
        transform1.rotation = rotation;
        //every time a tool is set active it is saved as the current tool
        ToolManager2.instance.RegistrateCurrentUsedTool(this);
        //TestManager.instance.RegistrateCurrentUsedTool(this);
    }
}
