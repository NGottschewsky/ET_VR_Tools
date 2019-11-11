using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class ExperimentManager : MonoBehaviour
{
    [Header("Experiment components")] 
    public TextMeshProUGUI cue;
    public CueController cueController;
    private List<string> _cues;
    
    private void Start()
    {
        Debug.Log(string.Format("Reached"));
        _cues = new List<string> {"Lift", "Use"};
        cue = new TextMeshProUGUI();
       //"Welcome to the Experiment.", _cueColour);
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(string.Format("Reached Point2"));
        cueController.ShowText("Welcome to the Experiment.");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cueController.ShowText(_cues[Mathf.FloorToInt(Random.Range(0, _cues.Count))]);
        }
        Debug.Log(string.Format("Reached Point3"));
    }
}
