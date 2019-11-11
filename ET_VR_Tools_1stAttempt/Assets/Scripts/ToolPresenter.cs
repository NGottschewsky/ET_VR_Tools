using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToolPresenter : MonoBehaviour
{
    public GameObject tool;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(tool);
        }
    }
}
