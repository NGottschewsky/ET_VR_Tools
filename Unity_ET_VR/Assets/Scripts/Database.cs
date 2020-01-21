using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;

public class Database : MonoBehaviour
{
    // actual data
    public Exp_ParticipantInfo experiment;

    public Database()
    {
        experiment = new Exp_ParticipantInfo();
    }

    //get current u long timestamp
    public double getCurrentTimestamp()
    {
        System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        return (System.DateTime.UtcNow - epochStart).TotalSeconds;
    }

    // saving
    public void Save(int block)
    {
        string json = JsonUtility.ToJson(this, true);
        using (StreamWriter sw = File.CreateText("Assets/jsonFiles/subject" + experiment.ID.ToString("00") + "_block" +
                                                 block.ToString() + ".json"))
        {
            sw.WriteLine(json);
        }

        AssetDatabase.Refresh();

        experiment.blocks.Clear();
    }

    // singleton start
    private static volatile Database instance;

    public static Database Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Database();
            }

            return instance;
        }
    }

    // singleton end
}

[Serializable]
public class Exp_ParticipantInfo
{
    public int ID;
    public int age;
    public string gender;
    public List<Block> blocks;

    public Exp_ParticipantInfo()
    {
        blocks = new List<Block>();
    }
}

[Serializable]
public class Block
{
    public int ID;
    public List<Trial> trials;

    public Block()
    {
        trials = new List<Trial>();
    }
}

[Serializable]
public class Trial
{
    public int ID;
    public string toolModel; // Screwdriver etc. 
    public string toolOrientation; // Left or Right
    public List<Coll> colls; // Handle collider and effector collider 
    public string cue; // Lift or Use
    public double start;
    public double end;
    
    // Samples
    public List<FrameData> samples;

    public Trial()
    {
        colls = new List<Coll>();
        samples = new List<FrameData>();
    }
}

[Serializable]
public class Coll
{
    public string position; // Handle or effector
    public Vector3 center;
    public Vector3 size;
}

/*
[Serializable]
public class Cube
{
    public int ID;

    public string cubeType;
    public List<Vector3> cubePositions;

    public Cube()
    {
        cubePositions = new List<Vector3>();
    }
}


[Serializable]
public class Alignment
{
    public int ID;
    public double start;
    public double end;
    public string alignmentType;

    public int cube1_ID;
    public int cube2_ID;

    public Vector3 endPosCurrentCube;
    public List<FrameData> framedata;

    public Alignment()
    {
        framedata = new List<FrameData>();
    }
}
*/

[Serializable]
public class FrameData
{
    public double timeStamp;

    public Vector3 rightEyePos;
    public Vector3 leftEyePos;
    public Vector3 middlePointPos;
    public Vector3 hmdPos;

    public Vector3 rightEyeDirectionForward;
    public Vector3 leftEyeDirectionForward;
    public Vector3 middlePointDirectionForward;
    public Vector3 hmdDirectionForward;


    public Vector3 hmdDirectionUp;

    public List<RayHit> rightEyeHits;
    public List<RayHit> leftEyeHits;
    public List<RayHit> middlePointHits;
    
    // trigger pressed 
    // public bool 

    public FrameData()
    {
        rightEyeHits = new List<RayHit>();
        leftEyeHits = new List<RayHit>();
        middlePointHits = new List<RayHit>();
    }
}

[Serializable]
public class RayHit
{
    public Vector3 position;
    public int colliderID; // effector or handle, in string
}