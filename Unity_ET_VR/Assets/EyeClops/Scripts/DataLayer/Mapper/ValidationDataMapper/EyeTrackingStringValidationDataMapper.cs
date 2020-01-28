using System;
using System.Collections.Generic;
using EyeClops.Data;
using UnityEngine;

namespace EyeClops.DataLayer.Mapper.ValidationDataMapper
{
    public class EyeTrackingStringValidationDataMapper : EyeTrackingAbstractValidationDataMapper<string[]>
    {
        protected override string[] GenerateHeader()
        {
            string[] header = new string[base.PositionValueMap.Count];
            header[PositionValueMap[PointName]] = PointName;
            header[PositionValueMap[LastScaleX]] = LastScaleX;
            header[PositionValueMap[LastScaleY]] = LastScaleY;
            header[PositionValueMap[LastScaleZ]] = LastScaleZ;
            header[PositionValueMap[MeasuringTime]] = MeasuringTime;
            header[PositionValueMap[ValidationTrial]] = ValidationTrial;
            return header;
        }

        protected override void GenerateBody(List<EyeClopsValidationData> eyeTrackingValidationData,
            ref List<string[]> serializableData)
        {
            foreach (EyeClopsValidationData data in eyeTrackingValidationData)
            {
                var singleLine = new string[PositionValueMap.Count];
                singleLine[PositionValueMap[PointName]] = data.GetValidationPoint();
                singleLine[PositionValueMap[LastScaleX]] = data.GetLastPointScale().x.ToString();
                singleLine[PositionValueMap[LastScaleY]] = data.GetLastPointScale().y.ToString();
                singleLine[PositionValueMap[LastScaleZ]] = data.GetLastPointScale().z.ToString();
                singleLine[PositionValueMap[MeasuringTime]] = data.GetMeasuringTime().ToString();
                singleLine[PositionValueMap[ValidationTrial]] = data.GetValidationTrial().ToString();
                serializableData.Add(singleLine);
            }
        }

        public void GenerateDeserializedValidationData(List<string[]> csvFile,
            ref List<EyeClopsValidationData> eyeTrackingValidationData)
        {
            //Skiped the first line, because this is the header!
            Debug.Log("EyeTrackinValidationDataMapper and der Count des Inputs: " + csvFile.Count);
            for (int i = 1; i < csvFile.Count; i++)
            {
                string[] singleLine = csvFile[i];

                eyeTrackingValidationData.Add(new EyeClopsValidationData(
                    pointName: singleLine[PositionValueMap[PointName]],
                    lastPointScale:
                    new Vector3(float.Parse(singleLine[PositionValueMap[LastScaleX]]),
                        float.Parse(singleLine[PositionValueMap[LastScaleY]]),
                        float.Parse(singleLine[PositionValueMap[LastScaleZ]])),
                    measuringTime: float.Parse(singleLine[PositionValueMap[MeasuringTime]]),
                    validationTrial: Int32.Parse(singleLine[PositionValueMap[ValidationTrial]]),
                    gazeValidationData: null
                ));
            }
        }
    }
}