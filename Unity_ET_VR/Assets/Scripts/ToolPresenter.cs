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

    public IEnumerator PresentTool(ToolController tool, string orientation)
    {
        ToolManager2.instance.DeactivateLastTool();
        
        yield return new WaitForSeconds(3.0f);
        
        switch (orientation)
        {
            case "left" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionLeft.transform.position, ToolManager2.instance.spawnerPositionLeft.transform.rotation);
                break;
            case "right" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionRight.transform.position, ToolManager2.instance.spawnerPositionRight.transform.rotation);
                break;
            case "blumenschneider left" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionBLUMLeft.transform.position, ToolManager2.instance.spawnerPositionBLUMLeft.transform.rotation);
                break;
            case "blumenschneider right" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionBLUMRight.transform.position, ToolManager2.instance.spawnerPositionBLUMRight.transform.rotation);
                break;
            case "speichenschlüssel right" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionSPEICHRight.transform.position, ToolManager2.instance.spawnerPositionSPEICHRight.transform.rotation);
                break;
            case "speichenschlüssel left" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionSPEICHLeft.transform.position, ToolManager2.instance.spawnerPositionSPEICHLeft.transform.rotation);
                break;
            case "fork right" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionFORKRight.transform.position, ToolManager2.instance.spawnerPositionFORKRight.transform.rotation);
                break;
            case "fork left" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionFORKLeft.transform.position, ToolManager2.instance.spawnerPositionFORKLeft.transform.rotation);
                break;
            default :
                Debug.LogError("wrong orientation");
                break;
        }

    }

}