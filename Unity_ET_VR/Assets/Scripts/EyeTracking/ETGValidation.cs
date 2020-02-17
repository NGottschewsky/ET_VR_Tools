using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;
using ViveSR.anipal.Eye;

public class ETGValidation : MonoBehaviour
{
    public float distance;
    

    public List<Vector3> keyPositions;
//    public TextMeshProUGUI validationResultText;

    private int validationPointIdx;
    private int validationTrial;
    public float delay; 


    // Start is called before the first frame update

//    void Awake()

//    {

//        gameObject.SetActive(false);

//    }


    public void StartValidation()
    {
        gameObject.SetActive(true);
        StartCoroutine(Validate());
    }

//    public void Update()

//    {

////        transform.position = Player.instance.hmdTransform.position +

////                             Player.instance.hmdTransform.rotation * keyPositions[0];

//        if (Input.GetKeyDown(KeyCode.V))

//        {

//            StartValidation();

//        }

//    }


    private IEnumerator Validate()
    {
        yield return new WaitForSeconds(delay);
        List<float> anglesX = new List<float>();
        List<float> anglesY = new List<float>();
        List<float> anglesZ = new List<float>();
        validationTrial += 1;
        float startTime = Time.time;
        
        for (int i = 1; i < keyPositions.Count; i++)
        {
            startTime = Time.time;
            float timeDiff = 0;
            while (timeDiff < 1f)
            {
                transform.position = Player.instance.hmdTransform.position + Player.instance.hmdTransform.rotation * Vector3.Lerp(keyPositions[i-1], keyPositions[i], timeDiff / 1f);
                transform.LookAt(Player.instance.hmdTransform);
                yield return new WaitForEndOfFrame();
                timeDiff = Time.time - startTime;
            }

            validationPointIdx = i;
            startTime = Time.time;
            timeDiff = 0;
            
            while (timeDiff < 3f)
            {
                transform.position = Player.instance.hmdTransform.position + Player.instance.hmdTransform.rotation * keyPositions[i] ;
                transform.LookAt(Player.instance.hmdTransform);
                EyeValidationSample validationSample = GetValidationSample();
                

                if (validationSample != null && validationSample.validationData.CombinedEyeAngleOffset != null)
                {
                    anglesX.Add(validationSample.validationData.CombinedEyeAngleOffset.x);
                    anglesY.Add(validationSample.validationData.CombinedEyeAngleOffset.y);
                    anglesZ.Add(validationSample.validationData.CombinedEyeAngleOffset.z);
                    validationSample.Save(validationTrial);
                }
                yield return new WaitForEndOfFrame();
                timeDiff = Time.time - startTime;
            }
        }

        
        string validationResult = "(" + CalculateValidationError(anglesX).ToString("0.00") +
                                    ", " +
                                    CalculateValidationError(anglesY).ToString("0.00") +
                                    ", " +
                                    CalculateValidationError(anglesZ).ToString("0.00") + ")";
        Debug.LogWarning(validationResult);
        gameObject.SetActive(false);
        if (CalculateValidationError(anglesX) > 1 || CalculateValidationError(anglesY) > 1 ||
            CalculateValidationError(anglesZ) > 1)
        {
            SRanipal_Eye_v2.LaunchEyeCalibration();
        }
    }


    private float CalculateValidationError(List<float> angles)
    {
        return angles.Select(f => f > 180 ? Mathf.Abs(f - 360) : Mathf.Abs(f)).Sum() / angles.Count;
    }

    private EyeValidationSample GetValidationSample()
    {
        EyeValidationSample sample; 
        sample = GetViveValidationSample();
        

        sample.validationData.HeadTransform = Player.instance.hmdTransform;
//        sample.PointToFocus = transform.position.ToVec3();
        sample.validationData.PointToFocus = transform.position;

        return sample;
    }

    private EyeValidationSample GetViveValidationSample()
    {
        Ray ray;

        EyeValidationSample sample = EyeValidationSample.Instance;//new EyeValidationSample();

        sample.validationData.ValidationTrial = validationTrial;
        sample.validationData.ValidationPointIdx = validationPointIdx;
        sample.validationData.participantNr = ToolManager2.instance.participantNr;
        sample.validationData.block = ToolManager2.instance._block;
        
        var debText = "";

        sample.validationData.UnixTimestamp = sample.getCurrentTimestamp();//new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        sample.validationData.Timestamp = Time.realtimeSinceStartup;

        var hmdTransform = Player.instance.hmdTransform;

        if (SRanipal_Eye.GetGazeRay(GazeIndex.LEFT, out ray))
        {
            var angles = Quaternion.FromToRotation((transform.position - hmdTransform.position).normalized, hmdTransform.rotation * ray.direction)
                .eulerAngles;

            debText += "\nLeft Eye: " + angles + "\n";
            sample.validationData.LeftEyeAngleOffset = angles;
        }

        if (SRanipal_Eye.GetGazeRay(GazeIndex.RIGHT, out ray))
        {
            var angles = Quaternion.FromToRotation((transform.position - hmdTransform.position).normalized, hmdTransform.rotation * ray.direction)
                .eulerAngles;
            debText += "Right Eye: " + angles + "\n";
            sample.validationData.RightEyeAngleOffset = angles;
        }

        if (SRanipal_Eye.GetGazeRay(GazeIndex.COMBINE, out ray))
        {
            var angles = Quaternion.FromToRotation((transform.position - hmdTransform.position).normalized, hmdTransform.rotation * ray.direction)
                .eulerAngles;
            debText += "Combined Eye: " + angles + "\n";
            sample.validationData.CombinedEyeAngleOffset = angles;
        }

  
        Debug.Log(debText);
        

        return sample;
    }
}

