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
            case "fishscaler left" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionFISHLeft.transform.position, ToolManager2.instance.spawnerPositionFISHLeft.transform.rotation);
                break;
            case "fishscaler right" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionFISHRight.transform.position, ToolManager2.instance.spawnerPositionFISHRight.transform.rotation);
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
            case "spatula right" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionSPATRight.transform.position, ToolManager2.instance.spawnerPositionSPATRight.transform.rotation);
                break;
            case "spatula left" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionSPATLeft.transform.position, ToolManager2.instance.spawnerPositionSPATLeft.transform.rotation);
                break;
            case "paintbrush left" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionPAINTLeft.transform.position, ToolManager2.instance.spawnerPositionPAINTLeft.transform.rotation);
                break;
            case "paintbrush right" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionPAINTRight.transform.position, ToolManager2.instance.spawnerPositionPAINTRight.transform.rotation);
                break;
            case "paletteknife left" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionPALLLeft.transform.position, ToolManager2.instance.spawnerPositionPALLLeft.transform.rotation);
                break;
            case "paletteknife right" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionPALLRight.transform.position, ToolManager2.instance.spawnerPositionPALLRight.transform.rotation);
                break;
            case "screwdriver left" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionSCREWLeft.transform.position, ToolManager2.instance.spawnerPositionSCREWLeft.transform.rotation);
                break;
            case "screwdriver right" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionSCREWRight.transform.position, ToolManager2.instance.spawnerPositionSCREWRight.transform.rotation);
                break;
            case "shovel left" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionSHOVLeft.transform.position, ToolManager2.instance.spawnerPositionSHOVLeft.transform.rotation);
                break;
            case "shovel right" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionSHOVRight.transform.position, ToolManager2.instance.spawnerPositionSHOVRight.transform.rotation);
                break;
            case "unkrautstecher left" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionUNKLeft.transform.position, ToolManager2.instance.spawnerPositionUNKLeft.transform.rotation);
                break;
            case "unkrautstecher right" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionUNKRight.transform.position, ToolManager2.instance.spawnerPositionUNKRight.transform.rotation);
                break;
            case "zitronenschaber left" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionZITLeft.transform.position, ToolManager2.instance.spawnerPositionZITLeft.transform.rotation);
                break;
            case "zitronenschaber right" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionZITRight.transform.position, ToolManager2.instance.spawnerPositionZITRight.transform.rotation);
                break;
            case "wench left" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionWENLeft.transform.position, ToolManager2.instance.spawnerPositionWENLeft.transform.rotation);
                break;
            case "wench right" :
                tool.ActivateThis(ToolManager2.instance.spawnerPositionWENRight.transform.position, ToolManager2.instance.spawnerPositionWENRight.transform.rotation);
                break;
            default :
                Debug.LogError("wrong orientation");
                break;
        }

    }

}