using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ToolPresenter : MonoBehaviour
{

    public static readonly ToolPresenter INSTANCE = new ToolPresenter();

    private ToolPresenter()
    {
    }

    public static ToolPresenter Instance
    {
        get { return INSTANCE; }
    }

    public void PresentTool(ToolController tool, string orientation)
    {
        ToolManager2.instance.DeactivateLastTool();

        if (orientation == "left")
        {
            tool.ActivateThis(ToolManager2.instance.spawnerPositionLeft.transform.position, ToolManager2.instance.spawnerPositionLeft.transform.rotation);
            
        }
        else if(orientation == "right")
        {
            tool.ActivateThis(ToolManager2.instance.spawnerPositionRight.transform.position, ToolManager2.instance.spawnerPositionRight.transform.rotation);
        }
        else
        {
            Debug.LogError("wrong orientation");
        }
       
        

    }

}