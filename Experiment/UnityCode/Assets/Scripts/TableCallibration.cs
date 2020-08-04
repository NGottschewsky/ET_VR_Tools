using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCallibration : MonoBehaviour
{
    // Start is called before the first frame update
    public float scale;
    
    public void CalibrateHight(bool additive)
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

    public void CalibrateWidth(bool additive)
    {
        if (additive)
        {
            transform.localScale += new Vector3(scale,0,0);
        }
        else
        {
            transform.localScale -= new Vector3(scale, 0, 0);
        }
    }

    public void CalibrateDepth(bool additive)
    {
        if (additive)
        {
            transform.localScale += new Vector3(0,scale,0);
        }
        else
        {
            transform.localScale -= new Vector3(0,scale,0);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CalibrateHight(true);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            CalibrateHight(false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CalibrateWidth(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CalibrateWidth(false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CalibrateDepth(true);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CalibrateDepth(false);            
        }
    }
}
