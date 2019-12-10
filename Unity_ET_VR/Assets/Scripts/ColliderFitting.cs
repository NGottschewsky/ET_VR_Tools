using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFitting : MonoBehaviour
{
    /*private List<GameObject> _toolObjects;

    private List<BoxCollider> _boxColliders;

    private List<Bounds> _bounds;
    */

    private GameObject _tool;
    private ToolController _toolTest;
    private BoxCollider _bc;
    private Bounds _bound;
    
    private void Awake()
    {
        /*foreach (var tool in ToolManager2.instance._tools)
        {
            _toolObjects.Add(tool.GetComponent<GameObject>());
        }*/
        
        Debug.Log(ToolManager2.instance._tools[7].gameObject.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < _toolObjects.Count; i++)
        {
            _bounds.Add(_toolObjects[i].GetComponent<Renderer>().bounds);
            AddBoxColliders(_bounds[i]);
        }*/
        
        _bc = _tool.AddComponent(typeof(BoxCollider)) as BoxCollider;

        _bound = _tool.GetComponent<Renderer>().bounds;
        AddBoxColliders(_bound);

    }

    void AddBoxColliders(Bounds bound)
    {
        
        _bc.center = bound.center;
        _bc.size = bound.size;

        

        //_boxColliders.Add(box);
    }
}
