using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
    public bool LeftSide = false;

    public Transform tool;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //if(steamVTInput.grab)
        // grabbing
        if (tool != null)
        {
            //do thing
        }
        throw new NotImplementedException();
    }
}
