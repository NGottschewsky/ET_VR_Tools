using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCallibration : MonoBehaviour
{
    // Start is called before the first frame update
    public float scale = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Callibrate(bool additive)
    {
        if (additive)
        {
            transform.localScale += new Vector3(0, 0, scale);
        }
        else
        {
            transform.localScale -= new Vector3(0,0,scale);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Callibrate(true);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Callibrate(false);
        }
    }
}
