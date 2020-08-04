using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Tobii.XR;
using ViveSR.anipal.Eye;

public class ToolManager2 : MonoBehaviour
{
    [Header("Experiment components")]
    public CuePresenter cuePresenter;
    public ToolPresenter toolPresenter;
    public EyeTrackingManager eyeTrackingManager;
    public Canvas cueCanvas;
    private OtherTrialManager _otherTrialManager;
    
    [Header("Experiment parameters")] [Range(1, 20)]
    public int participantNr;
    //public int participantID;
    public string gender;
    public int age;
    public int _block;//1;
    
    // make a singleton instance of ToolManager to be able to call RegistrateCurrentUsedTool method etc. 
    public static ToolManager2 instance;

    [Header("Tool Models")] 
    [SerializeField] public List<ToolController> _tools; //List of all tool prefabs in diff. orientations and with diff. cues (48 in total)
    [SerializeField] public GameObject spawnerPositionSPEICHRight;
    [SerializeField] public GameObject spawnerPositionSPEICHLeft;
    [SerializeField] public GameObject spawnerPositionFORKRight;
    [SerializeField] public GameObject spawnerPositionFORKLeft;
    [SerializeField] public GameObject spawnerPositionBLUMLeft;
    [SerializeField] public GameObject spawnerPositionBLUMRight;
    [SerializeField] public GameObject spawnerPositionSPATLeft;
    [SerializeField] public GameObject spawnerPositionSPATRight;
    [SerializeField] public GameObject spawnerPositionFISHRight;
    [SerializeField] public GameObject spawnerPositionFISHLeft;
    [SerializeField] public GameObject spawnerPositionPAINTRight;
    [SerializeField] public GameObject spawnerPositionPAINTLeft;
    [SerializeField] public GameObject spawnerPositionSCREWLeft;
    [SerializeField] public GameObject spawnerPositionSCREWRight;
    [SerializeField] public GameObject spawnerPositionSHOVLeft;
    [SerializeField] public GameObject spawnerPositionSHOVRight;
    [SerializeField] public GameObject spawnerPositionUNKRight;
    [SerializeField] public GameObject spawnerPositionUNKLeft;
    [SerializeField] public GameObject spawnerPositionWENRight;
    [SerializeField] public GameObject spawnerPositionWENLeft;
    [SerializeField] public GameObject spawnerPositionZITLeft;
    [SerializeField] public GameObject spawnerPositionZITRight;
    [SerializeField] public GameObject spawnerPositionPALLLeft;
    [SerializeField] public GameObject spawnerPositionPALLRight;

    // List of tools that should be presented with left or right orientation respectively
    private string[] _leftTools = new string[] {"1", "2","5","6","29","30","45","46","9", "10", "13", "14", "17", "18", "21", "22", "25", "26", "33", "34", "37", "38", "41", "42"};
    //private string[] _differentLeftTools = new string[] {"1", "2","5","6","29","30","45","46"};
    private string[] _rightTools = new string[] {"3", "4", "7","8","31","32","47","48","11", "12","15", "16", "19", "20", "23", "24", "27", "28", "35", "36", "39", "40", "43", "44"};
    //private string[] _differentRightTools = new string[] {"3", "4", "7","8","31","32","47","48"};

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
    //private string _filePath = "D:\\Studium\\Bachelorarbeit\\ET_VR_Tools\\PermutationMatrix\\ExperimentLoopMatrixNewStats_WithLegend.csv";
    private const string FilePath = "D:\\NinaETVR\\ET_VR_Tools\\PermutationMatrix\\ExperimentLoopMatrixNewStats_WithLegend.csv";
    //private const string FilePath = "D:\\NinaETVR\\ET_VR_Tools\\PermutationMatrix\\Spatula.csv";
    
    private bool _endOfBlock = false; // set to true after 144 trials
    private bool _endOfTrial = false; // set to true in method where new trial is started
    private bool _blocked = false;

    // last used tool is saved so that it can be deactivated before the new tool is activated 
    private ToolController _lastUsedTool;

    // singleton instance of class Database is creatd, 1 instance per participant
    private Database _database = Database.Instance;
    private float _samplingRate = 1/90f; // 90 Hz sampling rate for eye-tracking samples and controller position samples
    
    public SteamVR_Action_Boolean grabPinch; //Grab Pinch is the trigger, select from inspector
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.RightHand; //which controller
    public Hand hand;
    private Transform _handTransform;
    private Transform _hmdTransform;

    //public Camera c;
    //private Transform _cameraTransform;
    

    #region Singelton
    //make ToolManager2 singleton to be able to create 1 instance on which to call its methods
    private void Awake()
    {
        if (instance == null)
            instance = this;
        //c = Camera.main;
        _hmdTransform = Player.instance.hmdTransform;
        _otherTrialManager = OtherTrialManager.instance;
    }

    #endregion
    
    /*
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
        Debug.Log("Trigger pressed.");
        /*double triggerTime = _database.getCurrentTimestamp();
        if (_database.experiment.blocks.Last().trials.LastOrDefault() != default)
        {
            _database.experiment.blocks.Last().trials.Last().triggerEvents.Add(triggerTime);
        }
    } */

    private IEnumerator RecordControllerTriggerAndPositionData()
    {
        while (!_endOfTrial)
        {
            yield return new WaitForSeconds(_samplingRate);
            FrameData f = new FrameData();
            var eyeTrackingDataWorld = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);
            var eyeTrackingDataLocal = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.Local);

            if (eyeTrackingDataWorld.GazeRay.IsValid)
            {
                
                f.tobiiTimeStamp = eyeTrackingDataWorld.Timestamp;
                f.eyePosWorld = eyeTrackingDataWorld.GazeRay.Origin;
                f.eyeDirWorld = eyeTrackingDataWorld.GazeRay.Direction;
                f.isLeftBlinkingW = eyeTrackingDataWorld.IsLeftEyeBlinking;
                f.isRightBlinkingW = eyeTrackingDataWorld.IsRightEyeBlinking;
                RaycastHit hitInfo;
                if (Physics.Raycast( eyeTrackingDataWorld.GazeRay.Origin, eyeTrackingDataWorld.GazeRay.Direction, out hitInfo))
                {
                    f.hitObjectName = hitInfo.collider.name;
                    f.hitPointOnObject = hitInfo.point;
                    f.hitObjectCenterInWorld = hitInfo.collider.transform.position;
                }
            }

            if (eyeTrackingDataLocal.GazeRay.IsValid)
            {
                f.eyePosLocal = eyeTrackingDataLocal.GazeRay.Origin;
                f.eyeDirLocal = eyeTrackingDataLocal.GazeRay.Direction;
                f.isLeftBlinkingL = eyeTrackingDataLocal.IsLeftEyeBlinking;
                f.isRightBlinkingL = eyeTrackingDataLocal.IsRightEyeBlinking;
            }
            
            f.timeStamp = _database.getCurrentTimestamp();
            f.triggerPressed = grabPinch.state;
            f.controllerTransform = _handTransform;
            f.controllerPosition = _handTransform.position;
            f.controllerRotation = _handTransform.rotation.eulerAngles;
            f.controllerScale = _handTransform.lossyScale;
            //f.hmdPos = _cameraTransform.position;
            f.hmdPos = _hmdTransform.position;
            //f.hmdDirectionForward = _cameraTransform.forward;
            f.hmdDirectionForward = _hmdTransform.forward;
            //f.hmdDirectionUp = _cameraTransform.up;
            f.hmdDirectionUp = _hmdTransform.up;
            //f.hmdDirectionRight = _cameraTransform.right;
            f.hmdDirectionRight = _hmdTransform.right;
            //f.hmdRotation = _cameraTransform.rotation.eulerAngles;
            f.hmdRotation = _hmdTransform.rotation.eulerAngles;

            if (_database.experiment.blocks.Last().trials.LastOrDefault() != default)
            {
                _database.experiment.blocks.Last().trials.Last().framedata.Add(f);
            }
            //_database.experiment.blocks.Last().trials.Last().framedata.Add(f);
            
            //Debug.Log(_database.experiment.blocks.Last().trials.Last().framedata.Last().isLeftBlinkingW);
            
            
        }
    }
    
    /*
    private IEnumerator GetPoseData()
    {
        throw new NotImplementedException();
    } 
    */
   
    void Start()
    {
        
        _trial = 0;
        
        _toolOrder = ReadCsvFile(FilePath);

        _totalNrofTrials = _toolOrder[participantNr-1].Length;
        
        _nrOfTrialsPerBlock = (_toolOrder[participantNr-1].Length)/6; //((_toolOrder[participantNr-1].Length)/2); /// 2;
        
        Debug.LogWarning("total number of trials =" + _totalNrofTrials);
        //if (c != null) _cameraTransform = c.transform;
        if (hand != null) _handTransform = hand.transform;
        
        Block b = new Block();
        b.ID = _block;
        _database.experiment.blocks.Add(b);
        _database.experiment.participantNr = participantNr;
        //_database.experiment.ID = participantID;
        _database.experiment.age = age;
        _database.experiment.gender = gender;
        
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
            if (Array.Exists(_leftTools, element => element == tool.id))// || Array.Exists(_differentLeftTools, element => element == tool.id))
            {
                tool.orientation = "left";
            }
            else if (Array.Exists(_rightTools, element => element == tool.id))// || Array.Exists(_differentRightTools, element => element == tool.id))
            {
                tool.orientation = "right";
            }
        }

    }

    
    
    private void GetNextTool(out ToolController returnTool)
    {
        returnTool = null; //new ToolController();
        
        foreach (var toolController in _tools)
        {
            
            if (toolController.id == _toolOrder[participantNr][_trial])
            {
                returnTool = toolController;
                _database.experiment.blocks.Last().trials.Last().toolModel = returnTool.name;
                _database.experiment.blocks.Last().trials.Last().toolOrientation = returnTool.orientation;
                _database.experiment.blocks.Last().trials.Last().cue = returnTool.cue;
                //_database.experiment.blocks.Last().trials.Last().toolTransform = returnTool.transform;
                _database.experiment.blocks.Last().trials.Last().toolPosition = returnTool.transform.position;
                _database.experiment.blocks.Last().trials.Last().toolRotation = returnTool.transform.rotation.eulerAngles;
                _database.experiment.blocks.Last().trials.Last().toolScale = returnTool.transform.lossyScale;
                
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
        if (_trial ==_nrOfTrialsPerBlock)
        {
            Debug.Log("end of block set true");
            EndOfBlock();
            Debug.Log("_endOfBlock: " + _endOfBlock);
            //_endOfBlock = true; 
        }

        if (TrialEndReached())
        {
            if (_endOfBlock && !_blocked)
            {
                _blocked = true;
                Debug.Log("End of Block");
                ShowMessage(Color.red, "End of block", 40);
                _otherTrialManager.ResetTriggerValue();
                _endOfBlock = false;
                if (_database.experiment.blocks.Last().trials.LastOrDefault() != default)
                {
                    _database.experiment.blocks.Last().trials.Last().end = _database.getCurrentTimestamp();
                    _endOfTrial = true;

                    StopCoroutine(RecordControllerTriggerAndPositionData());
                }

                Debug.Log("The block is over");
                cueCanvas.gameObject.SetActive(true);
                DeactivateLastTool();
                //Todo: fix back to normal 
                //StartCoroutine(_database.Save(_block));
                _database.SaveFarbod(_block);
                _block++;
                _nrOfTrialsPerBlock += 24;
                if (_block <= 6)
                {
                    _database = Database.Instance;
                    Block b = new Block();
                    b.ID = _block;
                    _database.experiment.blocks.Add(b);
                    _database.experiment.participantNr = participantNr;
                    //_database.experiment.ID = participantID;
                    _database.experiment.age = age;
                    _database.experiment.gender = gender;
                    //ShowMessage(Color.red, "End of block", 40);
                    Debug.Log(_database.experiment.blocks.Last().ID);
                    _blocked = false;
                    //StartCoroutine(ShowMessageCoroutine());
                    // Call calibration function for eye tracker here again DONE
                    //SRanipal_Eye_v2.LaunchEyeCalibration();
                }
                else
                {
                    ShowMessage(Color.red,"End of experiment", 40);
                }
                
            }
            else
            {
                Debug.Log("next trial");
                if (_trial == 36 || _trial == 108)
                {
                    /*eyeTrackingManager.validator.gameObject.SetActive(true);

                    if (eyeTrackingManager.validator != null)
                    {
                        eyeTrackingManager.validator.StartValidation();
                    }
                    else
                    {
                        Debug.LogError("ETGValidation field is not setup.");
                    }*/
                    Debug.Log("Time to validate");
                }

                cueCanvas.gameObject.SetActive(true);
                if (_database.experiment.blocks.LastOrDefault() == default)
                {
                    Debug.Log("hier ist das problem");
                }

                if (_database.experiment.blocks.LastOrDefault() != default)
                {
                    if (_database.experiment.blocks.Last().trials.LastOrDefault() != default)
                    {
                        _database.experiment.blocks.Last().trials.Last().end = _database.getCurrentTimestamp();
                        _endOfTrial = true;

                        StopCoroutine(RecordControllerTriggerAndPositionData());
                    }
                }

                Trial t = new Trial();
                t.ID = _trial;
                t.start = _database.getCurrentTimestamp();
                _database.experiment.blocks.Last().trials.Add(t);
                _endOfTrial = false;
                StartCoroutine(RecordControllerTriggerAndPositionData());
                Debug.Log(_database.experiment.blocks.Last().trials.Last().ID);

                GetNextTool(out var internalTool);
                //TrialManager.colliderInstance.ResetTriggerValue();
                _otherTrialManager.ResetTriggerValue();

                if (internalTool != null)
                {
                    if (Array.Exists(_liftCue, element => element == internalTool.id))
                    {
                        ShowMessage(Color.white, "   ", 60);
                        StartCoroutine(ShowMessageCoroutine(Color.white, "Lift", 60));
                        StartCoroutine(DisableCanvas());
                    }
                    else if (Array.Exists(_useCue, element => element == internalTool.id))
                    {
                        ShowMessage(Color.white, "   ", 60);
                        StartCoroutine(ShowMessageCoroutine(Color.white, "Use", 60));
                        StartCoroutine(DisableCanvas());
                    }
                    else
                    {
                        Debug.Log("Tool Id in neither cue list");
                    }


                    /*if (Array.Exists(_leftTools, element => element == internalTool.id))
                    {
                        StartCoroutine(ToolPresenter.INSTANCE.PresentTool(internalTool, "left"));
                    }
                    else if (Array.Exists(_rightTools, element => element == internalTool.id))
                    {
                        StartCoroutine(ToolPresenter.INSTANCE.PresentTool(internalTool, "right"));
                    }
                    else
                    {*/
                    switch (internalTool.id)
                    {
                        case "1":
                        case "2":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "spatula left"));
                            break;
                        case "3":
                        case "4":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "spatula right"));
                            break;
                        case "5":
                        case "6":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "blumenschneider left"));
                            break;
                        case "7":
                        case "8":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "blumenschneider right"));
                            break;
                        case "9":
                        case "10":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "fishscaler left"));
                            break;
                        case "11":
                        case "12":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "fishscaler right"));
                            break;
                        case "13":
                        case "14":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "paintbrush left"));
                            break;
                        case "15":
                        case "16":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "paintbrush right"));
                            break;
                        case "17":
                        case "18":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "paletteknife left"));
                            break;
                        case "19":
                        case "20":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "paletteknife right"));
                            break;
                        case "21":
                        case "22":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "screwdriver left"));
                            break;
                        case "23":
                        case "24":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "screwdriver right"));
                            break;
                        case "25":
                        case "26":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "shovel left"));
                            break;
                        case "27":
                        case "28":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "shovel right"));
                            break;
                        case "29":
                        case "30":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "speichenschlüssel left"));
                            break;
                        case "31":
                        case "32":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "speichenschlüssel right"));
                            break;
                        case "33":
                        case "34":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "unkrautstecher left"));
                            break;
                        case "35":
                        case "36":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "unkrautstecher right"));
                            break;
                        case "37":
                        case "38":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "wench left"));
                            break;
                        case "39":
                        case "40":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "wench right"));
                            break;
                        case "41":
                        case "42":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "zitronenschaber left"));
                            break;
                        case "43":
                        case "44":
                            StartCoroutine(
                                ToolPresenter.INSTANCE.PresentTool(internalTool, "zitronenschaber right"));
                            break;
                        case "45":
                        case "46":
                            StartCoroutine(ToolPresenter.INSTANCE.PresentTool(internalTool, "fork left"));
                            break;
                        case "47":
                        case "48":
                            StartCoroutine(ToolPresenter.INSTANCE.PresentTool(internalTool, "fork right"));
                            break;
                        default:
                            Debug.LogError("tool ID not contained in either list of tools");
                            break;
                    }
                   // }

                    _trial++;
                    _blocked = false;
                    _otherTrialManager.ResetTriggerValue();
                }
                else
                {
                    Debug.LogError("No tool returned.");
                }
            }
        }
    }

    private void EndOfBlock()
    {
        if (_endOfBlock == false)
            _endOfBlock = true;
    }

    // shows text after a 1 second delay
    IEnumerator ShowMessageCoroutine(Color32 color, string msg, int fontsize) 
    {
        yield return new WaitForSeconds(1.0f);
        cuePresenter.lableColor = color;
        cuePresenter.font = fontsize;
        cuePresenter.ShowText(msg);
        _database.experiment.blocks.Last().trials.Last().cueStart = _database.getCurrentTimestamp();
    }

    IEnumerator DisableCanvas()
    {
        yield return new WaitForSeconds(3.0f);
        cueCanvas.gameObject.SetActive(false);
        _database.experiment.blocks.Last().trials.Last().cueEnd = _database.getCurrentTimestamp();

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
        //return TrialManager.colliderInstance.GetTriggerValue();
        bool trialEnd = _otherTrialManager.GetTriggerValue();
        _otherTrialManager.ResetTriggerValue();
        return trialEnd;
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