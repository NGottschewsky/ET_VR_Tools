using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ToolPresenter : MonoBehaviour
{
    private Vector3 position;
    private Quaternion rotation;
    private bool _isPresent;
    private float[] _yCoordinate;

    private void Awake()
    {
    }

    void Start()
    {
        //_yCoordinate = new[] {0.7994252f, 0.8497297f};
        position = new Vector3(0.5f, 0.7994252f, 0.0f);
        rotation = new Quaternion(0, 0, 0, 0);
        _isPresent = false;
    }


    public static readonly ToolPresenter INSTANCE = new ToolPresenter();

    private ToolPresenter()
    {
    }

    public static ToolPresenter Instance
    {
        get { return INSTANCE; }
    }

    public void PresentTool(ToolController tool)
    {
        ToolManager2.instance.DeactivateLastTool();
        
        tool.ActivateThis(ToolManager2.instance.spawnerPosition.transform.position, rotation);
        

    }

}