using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UIElements;
using Valve.VR;

public class ToolManager2 : MonoBehaviour
{
    [Header("Experiment components")]
    public CuePresenter cuePresenter;
    public ToolPresenter toolPresenter;
    public TrialManager trialManager;
    
    [Header("Experiment parameters")] [Range(1, 20)]
    public int participantNr;
    public int participantID;
    public string gender;
    public int age;
    private int _block = 1;
    
    // make a singleton instance of ToolManager to be able to call RegistrateCurrentUsedTool method etc. 
    public static ToolManager2 instance;

    [Header("Tool Models")] 
    [SerializeField] public List<ToolController> _tools; //List of all tool prefabs in diff. orientations and with diff. cues (48 in total)
    [SerializeField] public GameObject spawnerPositionLeft;
    [SerializeField] public GameObject spawnerPositionRight;
    [SerializeField] public GameObject spawnerPositionSPEICHRight;
    [SerializeField] public GameObject spawnerPositionSPEICHLeft;
    [SerializeField] public GameObject spawnerPositionFORKRight;
    [SerializeField] public GameObject spawnerPositionFORKLeft;

    // List of tools that should be presented with left or right orientation respectively
    private string[] _leftTools = new string[] {"1", "2", "5", "6", "9", "10", "13", "14", "17", "18", "21", "22", "25", "26", "33", "34", "37", "38", "41", "42"};
    private string[] _rightTools = new string[] {"3", "4", "7", "8", "11", "12","15", "16", "19", "20", "23", "24", "27", "28", "35", "36", "39", "40", "43", "44"};
    
    // List of tools that should be presented in combination with lift or use cue respectively
    private string[] _liftCue = new string[] {"1", "3", "5", "7", "9", "11", "13", "15", "17", "19", "21", "23", "25", "27", "29", "31", "33", "35", "37", "39", "41", "43", "45", "47"};
    private string[] _useCue = new string[] {"2", "4", "6", "8", "10", "12","14", "16", "18", "20", "22", "24", "26", "28", "30", "32", "34", "36", "38", "40", "42", "44", "46", "48"};

    // Current trial (up to 144) 
    private int _trial;
    private int _totalNrofTrials;
    private int _nrOfTrialsPerBlock;

    // randomised order of tools (48 different) is stored in a list of arrays, each array for representing one participant
    private List<string[]> _toolOrder = new List<string[]>();
    
    //private string _filePath = "D:\\Nina_ET_VR\\ET_VR_Tools\\PermutationMatrix\\ExperimentLoopMatrixNewStats_WithLegend.csv";
    // csv file that contains the order of tool presentation and is read into the _toolOrder list
    private string _filePath = "D:\\Studium\\Bachelorarbeit\\ET_VR_Tools\\PermutationMatrix\\ExperimentLoopMatrixNewStats_WithLegend.csv";
    
    private bool _endOfBlock = false; // set to true after 144 trials
    private bool _endOfTrial = false; // set to true in method where new trial is started

    // last used tool is saved so that it can be deactivated before the new tool is activated 
    private ToolController _lastUsedTool;

    // singleton instance of class Database is creatd, 1 instance per participant
    private Database _database = Database.Instance;
    
    
    public SteamVR_Action_Boolean grabPinch; //Grab Pinch is the trigger, select from inspector
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any; //which controller
    public SteamVR_Behaviour_Pose rightHand;

    public SteamVR_Input_Sources RightHand = SteamVR_Input_Sources.RightHand;
    
    // add an Event listener to the SteamVR action grab grip 
    void OnEnable()
    {
        if (grabPinch != null)
        {
            grabPinch.AddOnChangeListener(VRController_OnInteract_ButtonPressed, inputSource);
            //rightHand.onTransformUpdated.AddListener;
        }
    }

    private void OnDisable()
    {
        if (grabPinch != null)
        {
            grabPinch.RemoveOnChangeListener(VRController_OnInteract_ButtonPressed, inputSource);
        }
    }

    // "Button pressed" saves the time of the trigger pulling as well as the trigger releasing, so every second saved 
    // timepoint is the pulled trigger and every other timepoint is the released trigger
    private void VRController_OnInteract_ButtonPressed(SteamVR_Action_Boolean action, SteamVR_Input_Sources sources,
        bool isConnected)
    {
        double triggerTime = _database.getCurrentTimestamp();
        if (_database.experiment.blocks.Last().trials.LastOrDefault() != default)
        {
            _database.experiment.blocks.Last().trials.Last().triggerEvents.Add(triggerTime);
            Debug.Log(_database.experiment.blocks.Last().trials.Last().triggerEvents.Last());
        }
    }

    private IEnumerator GetPoseData()
    {
        throw new NotImplementedException();
    }
   
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

        _totalNrofTrials = _toolOrder[participantNr].Length;
        _nrOfTrialsPerBlock = _totalNrofTrials / 2;
        
        Block b = new Block();
        b.ID = _block;
        _database.experiment.blocks.Add(b);
        _database.experiment.participantNr = participantNr;
        _database.experiment.ID = participantID;
        _database.experiment.age = age;
        _database.experiment.gender = gender;
        
        Debug.Log(_database.experiment.gender);
        Debug.Log(_database.experiment.age);

        foreach (var tool in _tools)
        {
            if (Array.Exists(_liftCue, element => element == tool.id))
            {
                tool.cue = "lift";
            }
            else if(Array.Exists(_useCue, element => element == tool.id))
            {
                tool.cue = "use";
            }
            if (Array.Exists(_leftTools, element => element == tool.id))
            {
                tool.orientation = "left";
            }
            else if (Array.Exists(_rightTools, element => element == tool.id))
            {
                tool.orientation = "right";
            }
        }
    }


    
    private void GetNextTool(out ToolController returnTool)
    {
        returnTool = new ToolController();
        
        foreach (var toolController in _tools)
        {
            
            if (toolController.id == _toolOrder[participantNr][_trial])
            {
                returnTool = toolController;
                _database.experiment.blocks.Last().trials.Last().toolModel = returnTool.name;
                _database.experiment.blocks.Last().trials.Last().toolOrientation = returnTool.orientation;
                _database.experiment.blocks.Last().trials.Last().cue = returnTool.cue;
                _database.experiment.blocks.Last().trials.Last().toolPosition = returnTool.transform;
                Debug.Log(_database.experiment.blocks.Last().trials.Last().toolPosition.position);
                Debug.Log(_database.experiment.blocks.Last().trials.Last().toolPosition.rotation);
                Debug.Log(_database.experiment.blocks.Last().trials.Last().toolPosition);

                Debug.Log(_database.experiment.blocks.Last().trials.Last().toolModel);
                Debug.Log(_database.experiment.blocks.Last().trials.Last().toolOrientation);
                Debug.Log(_database.experiment.blocks.Last().trials.Last().cue = returnTool.cue);

                for (int i = 0; i < returnTool.transform.childCount; i++)
                {
                    Transform child = returnTool.transform.GetChild(i);
                    
                    if (child.CompareTag("Handle") || child.CompareTag("Effector"))
                    {
                        Coll coll = new Coll
                        {
                            position = child.tag,
                            size = child.GetComponent<BoxCollider>().size,
                            center = child.GetComponent<BoxCollider>().center
                        };
                        _database.experiment.blocks.Last().trials.Last().colls.Add(coll);
                    }
                }
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
        if (_trial == _nrOfTrialsPerBlock)
        {
            _endOfBlock = true; 
        }
        
        if (TrialEndReached() && !_endOfBlock)  //Input.GetKeyDown(KeyCode.Space) && !_endOfBlock)
        {
            if (_database.experiment.blocks.Last().trials.LastOrDefault() != default)
            {
                _database.experiment.blocks.Last().trials.Last().end = _database.getCurrentTimestamp();
            }
            Trial t = new Trial();
            t.ID = _trial;
            t.start = _database.getCurrentTimestamp();
            _database.experiment.blocks.Last().trials.Add(t);
            Debug.Log(_database.experiment.blocks.Last().trials.Last().ID);
            
            GetNextTool(out var internalTool);
            TrialManager.colliderInstance.ResetTriggerValue();
            
            
            if (Array.Exists(_liftCue, element => element == internalTool.id))
            {
                ShowMessage(Color.white, "   ", 60);
                StartCoroutine(ShowMessageCoroutine(Color.white, "Lift", 60));
            }
            else if(Array.Exists(_useCue, element => element == internalTool.id))
            {
                ShowMessage(Color.white, "   ", 60);
                StartCoroutine(ShowMessageCoroutine(Color.white, "Use", 60));

            }
            else
            {
                Debug.Log("Tool Id in neither cue list");
            }
            
            
            if (Array.Exists(_leftTools, element => element == internalTool.id))
            {
                StartCoroutine(ToolPresenter.INSTANCE.PresentTool(internalTool, "left"));
            }
            else if (Array.Exists(_rightTools, element => element == internalTool.id))
            {
                StartCoroutine(ToolPresenter.INSTANCE.PresentTool(internalTool, "right"));
            }
            else
            {
                switch (internalTool.id)
                {
                    case "29" :
                    case "30" :    
                        StartCoroutine(ToolPresenter.INSTANCE.PresentTool(internalTool,"speichenschlüssel left"));
                        break;
                    case "31" :
                    case "32" :    
                        StartCoroutine(ToolPresenter.INSTANCE.PresentTool(internalTool,"speichenschlüssel right"));    
                        break;
                    case "45" :
                    case "46" :    
                        StartCoroutine(ToolPresenter.INSTANCE.PresentTool(internalTool,"fork left")); 
                        break;
                    case "47" :
                    case "48" :    
                        StartCoroutine(ToolPresenter.INSTANCE.PresentTool(internalTool,"fork right")); 
                        break;
                    default :
                        Debug.LogError("tool ID not contained in either list of tools");
                        break;
                }
            }

            _trial++;
            
        }

        if (TrialEndReached()  && _endOfBlock)
        {
            DeactivateLastTool();
            Debug.Log("End of Block.");
            TrialManager.colliderInstance.ResetTriggerValue();
            ShowMessage(Color.red, "End of Block", 50);
            _endOfBlock = false;
            _nrOfTrialsPerBlock = _totalNrofTrials;
            _block++;
            if (_block == 2)
            {
                Block b = new Block();
                b.ID = _block;
                _database.experiment.blocks.Add(b);
            }
        }
        
    }
    
    // shows text after a 1 second delay
    IEnumerator ShowMessageCoroutine(Color32 color, string msg, int fontsize) 
    {
        yield return new WaitForSeconds(1.0f);
        cuePresenter.lableColor = color;
        cuePresenter.font = fontsize;
        cuePresenter.ShowText(msg);
    }
    
    // shows text without a delay 
    public void ShowMessage(Color32 color, string msg, int fontsize)
    {
        cuePresenter.lableColor = color;
        cuePresenter.font = fontsize;
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
        {
            _lastUsedTool.DeactivateThis();
        }
    }
    
    public void RegistrateCurrentUsedTool(ToolController tool)
    {
        _lastUsedTool = tool;
    }

}