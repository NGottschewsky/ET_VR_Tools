using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UIElements;

public class ToolManager2 : MonoBehaviour
{
    [Header("Experiment components")]
    public CuePresenter cuePresenter;
    public ToolPresenter toolPresenter;
    public TrialManager trialManager;
    
    [Header("Experiment parameters")] 
    public int ParticipantNr;

    public static ToolManager2 instance;

    [Header("Tool Models")] 
    [SerializeField] public List<ToolController> _tools;
    [SerializeField] public GameObject spawnerPositionLeft;
    [SerializeField] public GameObject spawnerPositionRight;
    [SerializeField] public GameObject spawnerPositionSPEICHRight;
    [SerializeField] public GameObject spawnerPositionSPEICHLeft;
    [SerializeField] public GameObject spawnerPositionFORKRight;
    [SerializeField] public GameObject spawnerPositionFORKLeft;

    private string[] _leftTools = new string[] {"1", "2", "5", "6", "9", "10", "13", "14", "17", "18", "21", "22", "25", "26", "33", "34", "37", "38", "41", "42"};
    private string[] _rightTools = new string[] {"3", "4", "7", "8", "11", "12","15", "16", "19", "20", "23", "24", "27", "28", "35", "36", "39", "40", "43", "44"};
    
    private string[] _liftCue = new string[] {"1", "3", "5", "7", "9", "11", "13", "15", "17", "19", "21", "23", "25", "27", "29", "31", "33", "35", "37", "39", "41", "43", "45", "47"};
    private string[] _useCue = new string[] {"2", "4", "6", "8", "10", "12","14", "16", "18", "20", "22", "24", "26", "28", "30", "32", "34", "36", "38", "40", "42", "44", "46", "48"};

    private int _trial;

    private List<string[]> _toolOrder = new List<string[]>();
    
    private string _filePath = "D:\\Nina_ET_VR\\ET_VR_Tools\\PermutationMatrix\\ExperimentLoopMatrixNewStats_WithLegend.csv";
    //private string _filePath = "D:\\Studium\\Bachelorarbeit\\ET_VR_Tools\\PermutationMatrix\\ExperimentLoopMatrixNewStats_WithLegend.csv";
    
    private bool _endOfBlock = false;
    private bool _endOfTrial = false;

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

        if (TrialEndReached() && !_endOfBlock)  //Input.GetKeyDown(KeyCode.Space) && !_endOfBlock) //will be replaced with some controller event specified in TrialEndReached() 
        {
            
            GetNextTool(out var internalTool);
            TrialManager.colliderInstance.ResetTriggerValue();
            
            if (Array.Exists(_liftCue, element => element == internalTool.id))
            {
                ShowMessage(Color.white,"Lift" );
            }
            else if(Array.Exists(_useCue, element => element == internalTool.id))
            {
                ShowMessage(Color.white,"Use");
            }
            else
            {
                Debug.Log("Tool Id in neither cue list");
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
                switch (internalTool.id)
                {
                    case "29" :
                    case "30" :    
                        ToolPresenter.INSTANCE.PresentTool(internalTool,"speichenschlüssel left");
                        break;
                    case "31" :
                    case "32" :    
                        ToolPresenter.INSTANCE.PresentTool(internalTool,"speichenschlüssel right");    
                        break;
                    case "45" :
                    case "46" :    
                        ToolPresenter.INSTANCE.PresentTool(internalTool,"fork left"); 
                        break;
                    case "47" :
                    case "48" :    
                        ToolPresenter.INSTANCE.PresentTool(internalTool,"fork right"); 
                        break;
                    default :
                        Debug.LogError("tool ID not contained in either list of tools");
                        break;
                }
                
            }
            
            _trial++;
            
        }

        if (_trial == (_toolOrder[ParticipantNr].Length))
        {
            _endOfBlock = true;
            ShowMessage(Color.red,"End of Block");
        }

        if (Input.GetKeyDown(KeyCode.Space) && _endOfBlock)
        {
            Debug.Log("End of Block.");
            //Use textMeshPro to make text appear
        }
        
    }
    
    private void ShowMessage(Color32 color, string msg)
    {
        cuePresenter.lableColor = color;
        cuePresenter.ShowText(msg);
    }

    private bool TrialEndReached()
    {
        return TrialManager.colliderInstance.GetTriggerValue();
        //throw new NotImplementedException();
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