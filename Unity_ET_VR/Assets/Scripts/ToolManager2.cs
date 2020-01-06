using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;
using TMPro;

public class ToolManager2 : MonoBehaviour
{
    [Header("Experiment components")]
    public CuePresenter cuePresenter;
    public ToolPresenter toolPresenter;

    [Header("Experiment parameters")] 
    public int ParticipantNr;
    
    public static ToolManager2 instance;
    
    [Header("Tool Models")] 
    [SerializeField] public List<ToolController> _tools;
    [SerializeField] public GameObject spawnerPositionLeft;
    [SerializeField] public GameObject spawnerPositionRight;

    private string[] _leftTools = new string[] {"1", "2", "5", "6", "9", "10", "13", "14", "17", "18", "21", "22"};//, "25", "26", "29", "30", "33", "34", "37", "38", "41", "42", "45", "46"};
    private string[] _rightTools = new string[] {"3", "4", "7", "8", "11", "12", "15", "16", "19", "20", "23", "24"};//, "27", "28", "31", "32", "35", "36", "39", "40", "43", "44", "47", "48"};
    
    private int _trial;

    private List<string[]> _toolOrder = new List<string[]>();
    
    private string _filePath = "D:\\Nina_ET_VR\\ET_VR_Tools\\PermutationMatrix\\ExperimentLoopMatrix.csv";
    //private string _filePath = "D:\\Studium\\Bachelorarbeit\\ET_VR_Tools\\PermutationMatrix\\ExperimentLoopMatrix.csv";
    
    private bool _endOfBlock = false;

    private ToolController _lastUsedTool;

    
    
    #region Singelton
    //make ToolManager2 singleton to be able to create 1 instance on which to call its methods
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    #endregion


    
    void Start()
    {
        _trial = 0;
        
        _toolOrder = ReadCsvFile(_filePath);
        
        Debug.Log(_tools.Count + " tools found");
        
       /* Debug.Log(instance._tools[7].ToString());
        Debug.Log(instance._tools[7].GetComponent<GameObject>().ToString());
        Debug.Log(instance._tools[7].gameObject.ToString()); */
        
    }


    
    private void GetNextTool(out ToolController returnTool)
    {
        returnTool = new ToolController();
        
        foreach (var toolController in _tools)
        {
            
            if (toolController.id == _toolOrder[ParticipantNr][_trial])
            {
                returnTool = toolController;
            }
            
        }
    }
    
    
    public static List<string[]> ReadCsvFile(string path)
    {
        List<string[]> csvReadedFile = new List<string[]>();
        
        try
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                using (StreamReader csvReader = new StreamReader(fileStream))
                {
                    while (!csvReader.EndOfStream)
                    {
                        string readLine = csvReader.ReadLine();
                        string[] strings = readLine.Split(',');
                        csvReadedFile.Add(strings);
                    }
                }
            }
        }
        
        catch (Exception e)
        {
            Debug.LogError(e);
            throw;
        }
        
        return csvReadedFile;   
    }
    
    
    
    // Update is called once per frame
    void Update()
    {
//        if (TrialEndReached()) //condition that ends the trial
//        {
            /*GetNextTool(out var internalTool);
            ToolPresenter.INSTANCE.PresentTool(internalTool);
            if (_trial < 1) _trial++;*/
//        }

        if (Input.GetKeyDown(KeyCode.Space) && !_endOfBlock) //will be replaced with some controller event specified in TrialEndReached()
        {
            
            GetNextTool(out var internalTool);
            if ((_trial % 2) == 0)
            {
                ShowMessege(Color.white,"Lift" );
            }
            else
            {
                ShowMessege(Color.white,"Use");
            }
            
            if (Array.Exists(_leftTools, element => element == internalTool.id))
            {
                ToolPresenter.INSTANCE.PresentTool(internalTool, "left");
            }
            else if (Array.Exists(_rightTools, element => element == internalTool.id))
            {
                ToolPresenter.INSTANCE.PresentTool(internalTool, "right");
            }
            else
            {
                Debug.LogError("tool ID not contained in either list of tools");
            }
            _trial++;
            
        }

        if (_trial == (_toolOrder[ParticipantNr].Length))
        {
            _endOfBlock = true;
            ShowMessege(Color.red,"End of Block");
        }

        if (Input.GetKeyDown(KeyCode.Space) && _endOfBlock)
        {
            Debug.Log("End of Block.");
            //Use textMeshPro to make text appear
        }
        
    }
    
    private void ShowMessege(Color32 color, string msg)
    {
        cuePresenter.lableColor = color;
        cuePresenter.ShowText(msg);
    }

    private bool TrialEndReached()
    {
        throw new NotImplementedException();
        //if vr controller held into collider for 5 secs or if it is placed in a snapzone or smth similar
    }

    
    
    public void DeactivateLastTool()
    {
        if (_lastUsedTool != null)
            _lastUsedTool.DeactivateThis();
    }

    
    
    public void RegistrateCurrentUsedTool(ToolController tool)
    {
        _lastUsedTool = tool;
    }
}