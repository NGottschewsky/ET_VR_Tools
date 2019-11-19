using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Transactions;
using UnityEditor.PackageManager;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    //ToolController als Klasse, die die ID des jeweiligen Tools
    //und evtl in Zukunft noch andere Attribute speichert und
    //als Component an jedes Tool angehängt ist
    //private List<ToolController> _tools = new List<ToolController>();
    
    private List<ToolController> _tools = new List<ToolController>();
    
    //Anzahl der Trials, die bereits durchlaufen wurden
    
    private int _trial;
    
    //Die Reihenfolge, in der die Tools präsentiert werden sollen.
    //Soll für jeden Participant unterschiedlich sein und aus einer
    //CSV File importiert werden
    
    private string[] _toolOrder;
    private string _csvFilepath = "D:\\Nina_ET_VR\\NinaFirstAttempt\\ET_VR_Tools\\ExperimentLoopMatrixTest.csv";
    private List<string[]> _csvFileSeparated;
    
    //Position und Ausrichtung des präsentierten Tools
    
    private Vector3 _position;
    private Quaternion _rotation;
    
    //Sagt an, ob bereits ein Tool zu sehen ist oder nicht. 
    //this should be an attribute of another class of which
    //the tools are objects
    
    private bool _isPresent = false;
    
    
    private void Start()
    {
        _trial = 0;
        
        //Adde alle 
        
        foreach(GameObject toolPrefab in GameObject.FindGameObjectsWithTag("Tool"))
        {
            _tools.Add(toolPrefab.GetComponent<ToolController>());
        }
        _position = new Vector3(0.5f, 1.549906f,0.0f);
        _rotation = new Quaternion(0,0,0,0);

        ReadCSVFile(_csvFilepath, ref _csvFileSeparated);
        for(var i=0; i < _csvFileSeparated.Count; i++)
        {
            for (var j = 0; j < _csvFileSeparated[i].Length; j++)
            {
                _toolOrder[i] = _csvFileSeparated[i].ToString();
            }
        }
    }
    
    
    private ToolController GetNextTool()
    {
        //Wenn ich auf diese Art eine Variable initialisiere, werden mir davon hunderte
        //im Inspector erstellt, sobald ich play drücke. Aber ohne diese dummy variable
        //kann ich den return Wert nicht aus der foreach Schleife rausbekommen. Aber 
        //wenn ich nur in foreach ein return habe, kann ich den rückgabetypen nicht als 
        //ToolController angeben. Und wenn ich Null returne, läuft es auch nicht. 
        
        //maybe try "var values = Enum.GetValues(typeof(Foos));"
        
        var returnTool = gameObject.AddComponent<ToolController>();
        
        foreach (var tool in _tools)
        {
            if (gameObject != null)
            {
                //var currentTool = gameObject.AddComponent<ToolController>();
            
                if (tool.GetComponent<ToolController>().id.Equals(_toolOrder[_trial]))
                {
                    returnTool = tool;
                }
                //return tool;
            }
            else
            {
                Debug.Log("gameObject is null.");
            }
            
        }

        //ToolController currentTool;
        return returnTool;
    }

    
    void PresentTool(ToolController presentTool)
    {
        //if 1 tool is already on the table, it shouldn't be able to spawn another
        if (!_isPresent)
        {
            var toolInstance = Instantiate(presentTool.GetComponent<GameObject>(), _position, _rotation);
            _trial++;
        } 
    }
    
    public static void ReadCSVFile(string filePath, ref List<string[]> csvReadFile)
    {
        char[] csvSeparator = {','};
        try
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader csvReader = new StreamReader(fileStream))
                {
                    while (!csvReader.EndOfStream)
                    {
                        string readLine = csvReader.ReadLine();
                        if (readLine != null)
                        {
                            string[] strings = readLine.Split(csvSeparator);
                            csvReadFile.Add(strings);
                            Console.WriteLine(csvReadFile);
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            throw;
        }
    }
    
    
    private void Update()
    {
        if (GetNextTool() == null)
        {
            Debug.Log("GetNextTool doesn't work.");
        };
        if (Input.GetKeyDown(KeyCode.Space) && _trial<60)//muss es < oder <=60 sein?
        {
            PresentTool(GetNextTool());
            //1 tool is already on the table
            _isPresent = true;
        }
        
    }
}
