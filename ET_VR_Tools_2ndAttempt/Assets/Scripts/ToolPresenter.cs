using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPresenter: MonoBehaviour
{
    public Rigidbody[] toolPrefabs;
    private Vector3 position;
    private Quaternion rotation;

    private void Start()
    {
        position = new Vector3(0.5f, 1.549906f,0f);
        rotation = new Quaternion(0,0,0,0);
    }

    void presentTool(Rigidbody tool)
    {
        // add position and rotation to Instantiated tool
        var toolInstance = Instantiate(tool).GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            presentTool(toolPrefabs[0]);
        }
    }
}
