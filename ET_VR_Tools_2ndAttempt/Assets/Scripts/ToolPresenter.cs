using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPresenter: MonoBehaviour
{
    public GameObject[] toolPrefabs;
    private Vector3 _position;
    private Quaternion _rotation;
    //this should be an attribute of another class of which the tools are objects
    private bool _ispresent = false;

    private void Start()
    {
        //position at centre of table and directly on top of it
        _position = new Vector3(0.5f, 1.549906f,0.0f);
        _rotation = new Quaternion(0,0,0,0);
    }

    void presentTool(GameObject tool)
    {
        //if 1 tool is already on the table, it shouldn't be able to spawn another
        if (!_ispresent)
        {
            GameObject toolInstance = Instantiate(tool, _position, _rotation).GetComponent<GameObject>();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            presentTool(toolPrefabs[0]);
            //1 tool is already on the table
            _ispresent = true;
        } else if (Input.GetKeyDown(KeyCode.A))
        {
            presentTool((toolPrefabs[1]));
            //1 tool is already on the table
            _ispresent = true;
        }
    }
}
