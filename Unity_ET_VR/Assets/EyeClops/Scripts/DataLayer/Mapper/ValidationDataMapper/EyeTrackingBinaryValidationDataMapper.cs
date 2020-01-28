using System;
using System.Collections.Generic;
using EyeClops.Data;
using UnityEngine;
using static System.Text.Encoding;

namespace EyeClops.DataLayer.Mapper.ValidationDataMapper
{
    public class EyeTrackingBinaryValidationDataMapper : EyeTrackingAbstractValidationDataMapper<byte[][]>
    {
        protected override byte[][] GenerateHeader()
        {
            var header = new byte[base.PositionValueMap.Count][];
            header[PositionValueMap[PointName]] = ASCII.GetBytes(PointName);
            header[PositionValueMap[LastScaleX]] = ASCII.GetBytes(LastScaleX);
            header[PositionValueMap[LastScaleY]] = ASCII.GetBytes(LastScaleY);
            header[PositionValueMap[LastScaleZ]] = ASCII.GetBytes(LastScaleZ);
            header[PositionValueMap[MeasuringTime]] = ASCII.GetBytes(MeasuringTime);
            header[PositionValueMap[ValidationTrial]] = ASCII.GetBytes(ValidationTrial);
            return header;
        }

        protected override void GenerateBody(List<EyeClopsValidationData> eyeTrackingValidationData,
            ref List<byte[][]> serializableData)
        {
            foreach (EyeClopsValidationData data in eyeTrackingValidationData)
            {
                var singleLine = new byte[PositionValueMap.Count][];
                singleLine[PositionValueMap[PointName]] = ASCII.GetBytes(data.GetValidationPoint());
                singleLine[PositionValueMap[LastScaleX]] = BitConverter.GetBytes(data.GetLastPointScale().x);
                singleLine[PositionValueMap[LastScaleY]] = BitConverter.GetBytes(data.GetLastPointScale().y);
                singleLine[PositionValueMap[LastScaleZ]] = BitConverter.GetBytes(data.GetLastPointScale().z);
                singleLine[PositionValueMap[MeasuringTime]] = BitConverter.GetBytes(data.GetMeasuringTime());
                singleLine[PositionValueMap[ValidationTrial]] = BitConverter.GetBytes(data.GetValidationTrial());
                serializableData.Add(singleLine);
            }
        }

        public void GenerateDeserializedValidationData(List<byte[][]> binFile,
            ref List<EyeClopsValidationData> eyeTrackingValidationData)
        {
            //Skiped the first line, because this is the header!
            Debug.Log("EyeTrackinValidationBinaryDataMapper and der Count des Inputs: " + binFile.Count);
            float test = 0.111f;
            byte[] bytes = BitConverter.GetBytes(test);
            float newTest = BitConverter.ToSingle(bytes, 0);
            Debug.LogFormat("The test is: {0} binary is: {1} and the newTest is: {2}", test,
                BitConverter.ToString(bytes), newTest);
            for (int i = 1; i < binFile.Count; i++)
            {
//                Debug.Log("EyeTrackingValidationBinaryDataMapper " + i);
                byte[][] singleLine = binFile[i];
                string pointName = ASCII.GetString(singleLine[PositionValueMap[PointName]]);
                float xValue = BitConverter.ToSingle(singleLine[PositionValueMap[LastScaleX]], 0);
//                foreach (byte b in singleLine[PositionValueMap[LastScaleX]])
//                {
//                    Debug.Log("SingleElementX: " + b);
//                }
//
//                foreach (byte b in singleLine[PositionValueMap[LastScaleY]])
//                {
//                    Debug.Log("SingleElementY: " + b);
//                }

//                Debug.Log("SingleLine: " + pointName + " : " + singleLine[PositionValueMap[LastScaleX]].Length + " : " +
//                          singleLine[PositionValueMap[LastScaleY]].Length);

                float yValue = BitConverter.ToSingle(singleLine[PositionValueMap[LastScaleY]], 0);
                float zValue = BitConverter.ToSingle(singleLine[PositionValueMap[LastScaleZ]], 0);
                Vector3 lastPointScale = new Vector3(
                    xValue,
                    yValue,
                    zValue
                );
                float measuringTime = BitConverter.ToSingle(singleLine[PositionValueMap[MeasuringTime]], 0);
                int validationTrial = BitConverter.ToInt32(singleLine[PositionValueMap[ValidationTrial]], 0);
                var eyeClopsValidationData = new EyeClopsValidationData(
                    pointName: pointName,
                    lastPointScale: lastPointScale,
                    measuringTime: measuringTime,
                    validationTrial: validationTrial,
                    gazeValidationData: null
                );
                eyeTrackingValidationData.Add(eyeClopsValidationData);
            }
        }
    }
}