﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;
using UnityEngine.UIElements;

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
    public int participantNr;
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
    public string cue; // Lift or Use
    public double start;
    public double end;
    public double cueStart;
    public double cueEnd;
    public List<Coll> colls; // Handle collider and effector collider 
    //public Transform toolTransform;
    public Vector3 toolPosition;
    public Vector3 toolRotation;
    public Vector3 toolScale;
    public List<FrameData> framedata;
    
    // Samples
    public List<FrameData> samples;

    public Trial()
    {
        colls = new List<Coll>();
        samples = new List<FrameData>();
        framedata = new List<FrameData>();
    }
}

[Serializable]
public class Coll
{
    public string position; // Handle or effector
    public Vector3 center;
    public Vector3 size;
}

[Serializable]
public class FrameData
{
    public double timeStamp;
    public double tobiiTimeStamp;
    
    public Vector3 hmdPos;

    public Vector3 eyePosWorld;
    public Vector3 eyeDirWorld;
    public Vector3 eyePosLocal;
    public Vector3 eyeDirLocal;
    public bool isLeftBlinkingW;
    public bool isRightBlinkingW;
    public bool isLeftBlinkingL;
    public bool isRightBlinkingL;

    public Vector3 rightEyeDirectionForward;
    public Vector3 leftEyeDirectionForward;
    public Vector3 middlePointDirectionForward;
    public Vector3 hmdDirectionForward;
    public Vector3 hmdDirectionRight;
    public Vector3 hmdRotation;


    public Vector3 hmdDirectionUp;

//    public List<RayHit> rightEyeHits;
//    public List<RayHit> leftEyeHits;
//    public List<RayHit> middlePointHits;
    public string hitObjectName;
    public Vector3 hitPointOnObject;
    public Vector3 hitObjectCenterInWorld;

    // trigger pressed 
    public bool triggerPressed;
    public Transform controllerTransform;
    public Vector3 controllerPosition;
    public Vector3 controllerRotation;
    public Vector3 controllerScale;


//    public FrameData()


//    {


//        rightEyeHits = new List<RayHit>();


//        leftEyeHits = new List<RayHit>();


//        middlePointHits = new List<RayHit>();


//    }
}

[Serializable]
public class RayHit
{
    public Vector3 position;
    public int colliderID; // effector or handle, in string
}