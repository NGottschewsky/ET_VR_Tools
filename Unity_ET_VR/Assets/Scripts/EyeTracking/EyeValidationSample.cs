using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EyeValidationSample
{

    public EyeValidationData validationData;

    public EyeValidationSample()
    {
        validationData = new EyeValidationData();
    }

    //get current u long timestamp
    public double getCurrentTimestamp()
    {
        System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        return (System.DateTime.UtcNow - epochStart).TotalSeconds;
    }

    // saving
    public void Save(int validationNr)
    {
        string json = JsonUtility.ToJson(this, true);
        using (StreamWriter sw = File.CreateText("D:/NinaETVR/JSon/validationData/subject" +
                                                 validationData.participantNr.ToString("00") + "_nr" +
                                                 validationNr.ToString() + ".json"))
        {
            sw.WriteLine(json);
        }

        AssetDatabase.Refresh();

        //validationData.blocks.Clear();
    }

    // singleton start
    private static volatile EyeValidationSample instance;

    public static EyeValidationSample Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EyeValidationSample();
            }

            return instance;
        }
    }
}
// singleton end

[Serializable]
public class EyeValidationData
{
    public int participantNr;
    public int ValidationTrial;
    public int block;

    public int ValidationPointIdx;
    public double UnixTimestamp;
    public float Timestamp;
    public Transform HeadTransform;
    public Vector3 PointToFocus;
    public Vector3 LeftEyeAngleOffset;
    public Vector3 RightEyeAngleOffset;
    public Vector3 CombinedEyeAngleOffset;
    public Vector3 ValidationResults;
}

    

