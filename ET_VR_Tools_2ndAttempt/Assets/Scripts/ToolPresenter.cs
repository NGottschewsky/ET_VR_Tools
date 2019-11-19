using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ToolPresenter: MonoBehaviour
{
    
    public GameObject[] toolPrefabs;
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

    
    public void presentTool(GameObject tool)
    {
        if (!_isPresent)
        {
            // add position and rotation to Instantiated tool
            GameObject toolInstance = Instantiate(tool, position, rotation).GetComponent<GameObject>();
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            presentTool(toolPrefabs[0]);
            _isPresent = true;
        } else if (Input.GetKeyDown(KeyCode.A))
        {
            presentTool((toolPrefabs[1]));
            _isPresent = true;
        }
    }
    
   }


