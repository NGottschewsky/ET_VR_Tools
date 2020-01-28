using System;
using System.Collections.Generic;
using EyeClops.Data;
using UnityEngine;

namespace EyeClops.DataLayer.Mapper.EyeTrackingDataMapper
{
    public class EyeClopsStringDataMapper : EyeClopsAbstractDataMapper<string[]>
    {
        protected override string[] GenerateHeader()
        {
            var header = new string[PositionValueMap.Count];

            header[PositionValueMap[TimeStamp]] = TimeStamp;

            //LeftEyeData
            header[PositionValueMap[LeftEyeDataEyeOriginX]] = LeftEyeDataEyeOriginX;
            header[PositionValueMap[LeftEyeDataEyeOriginY]] = LeftEyeDataEyeOriginY;
            header[PositionValueMap[LeftEyeDataEyeOriginZ]] = LeftEyeDataEyeOriginZ;
            header[PositionValueMap[LeftEyeDataNormalizedGazeDirectionX]] = LeftEyeDataNormalizedGazeDirectionX;
            header[PositionValueMap[LeftEyeDataNormalizedGazeDirectionY]] = LeftEyeDataNormalizedGazeDirectionY;
            header[PositionValueMap[LeftEyeDataNormalizedGazeDirectionZ]] = LeftEyeDataNormalizedGazeDirectionZ;
            header[PositionValueMap[LeftEyeDataEyeOpeness]] = LeftEyeDataEyeOpeness;
            header[PositionValueMap[LeftEyeDataPupilDiameter]] = LeftEyeDataPupilDiameter;
            header[PositionValueMap[LeftEyeDataGazeVectorOriginX]] = LeftEyeDataGazeVectorOriginX;
            header[PositionValueMap[LeftEyeDataGazeVectorOriginY]] = LeftEyeDataGazeVectorOriginY;
            header[PositionValueMap[LeftEyeDataGazeVectorOriginZ]] = LeftEyeDataGazeVectorOriginZ;
            header[PositionValueMap[LeftEyeDataGazeVectorDirectionX]] = LeftEyeDataGazeVectorDirectionX;
            header[PositionValueMap[LeftEyeDataGazeVectorDirectionY]] = LeftEyeDataGazeVectorDirectionY;
            header[PositionValueMap[LeftEyeDataGazeVectorDirectionZ]] = LeftEyeDataGazeVectorDirectionZ;
            //RightEyeData
            header[PositionValueMap[RightEyeDataEyeOriginX]] = RightEyeDataEyeOriginX;
            header[PositionValueMap[RightEyeDataEyeOriginY]] = RightEyeDataEyeOriginY;
            header[PositionValueMap[RightEyeDataEyeOriginZ]] = RightEyeDataEyeOriginZ;
            header[PositionValueMap[RightEyeDataNormalizedGazeDirectionX]] = RightEyeDataNormalizedGazeDirectionX;
            header[PositionValueMap[RightEyeDataNormalizedGazeDirectionY]] = RightEyeDataNormalizedGazeDirectionY;
            header[PositionValueMap[RightEyeDataNormalizedGazeDirectionZ]] = RightEyeDataNormalizedGazeDirectionZ;
            header[PositionValueMap[RightEyeDataEyeOpeness]] = RightEyeDataEyeOpeness;
            header[PositionValueMap[RightEyeDataPupilDiameter]] = RightEyeDataPupilDiameter;
            header[PositionValueMap[RightEyeDataGazeVectorOriginX]] = RightEyeDataGazeVectorOriginX;
            header[PositionValueMap[RightEyeDataGazeVectorOriginY]] = RightEyeDataGazeVectorOriginY;
            header[PositionValueMap[RightEyeDataGazeVectorOriginZ]] = RightEyeDataGazeVectorOriginZ;
            header[PositionValueMap[RightEyeDataGazeVectorDirectionX]] = RightEyeDataGazeVectorDirectionX;
            header[PositionValueMap[RightEyeDataGazeVectorDirectionY]] = RightEyeDataGazeVectorDirectionY;
            header[PositionValueMap[RightEyeDataGazeVectorDirectionZ]] = RightEyeDataGazeVectorDirectionZ;

            //CombinedEyeData
            header[PositionValueMap[CombinedEyeDataConvergenceDistance]] = CombinedEyeDataConvergenceDistance;
            header[PositionValueMap[CombinedEyeDataGazeVectorOriginX]] = CombinedEyeDataGazeVectorOriginX;
            header[PositionValueMap[CombinedEyeDataGazeVectorOriginY]] = CombinedEyeDataGazeVectorOriginY;
            header[PositionValueMap[CombinedEyeDataGazeVectorOriginZ]] = CombinedEyeDataGazeVectorOriginZ;
            header[PositionValueMap[CombinedEyeDataGazeVectorDirectionX]] = CombinedEyeDataGazeVectorDirectionX;
            header[PositionValueMap[CombinedEyeDataGazeVectorDirectionY]] = CombinedEyeDataGazeVectorDirectionY;
            header[PositionValueMap[CombinedEyeDataGazeVectorDirectionZ]] = CombinedEyeDataGazeVectorDirectionZ;

            //FocusData
            header[PositionValueMap[LeftEyeFocusPositionX]] = LeftEyeFocusPositionX;
            header[PositionValueMap[LeftEyeFocusPositionY]] = LeftEyeFocusPositionY;
            header[PositionValueMap[LeftEyeFocusPositionZ]] = LeftEyeFocusPositionZ;
            header[PositionValueMap[LeftEyeFocusObjectName]] = LeftEyeFocusObjectName;
            header[PositionValueMap[LeftEyeFocusColliderObjectName]] = LeftEyeFocusColliderObjectName;

            header[PositionValueMap[RightEyeFocusPositionX]] = RightEyeFocusPositionX;
            header[PositionValueMap[RightEyeFocusPositionY]] = RightEyeFocusPositionY;
            header[PositionValueMap[RightEyeFocusPositionZ]] = RightEyeFocusPositionZ;
            header[PositionValueMap[RightEyeFocusObjectName]] = RightEyeFocusObjectName;
            header[PositionValueMap[RightEyeFocusColliderObjectName]] = RightEyeFocusColliderObjectName;
            
            header[PositionValueMap[CombinedEyeFocusPositionX]] = CombinedEyeFocusPositionX;
            header[PositionValueMap[CombinedEyeFocusPositionY]] = CombinedEyeFocusPositionY;
            header[PositionValueMap[CombinedEyeFocusPositionZ]] = CombinedEyeFocusPositionZ;
            header[PositionValueMap[CombinedEyeFocusObjectName]] = CombinedEyeFocusObjectName;
            header[PositionValueMap[CombinedEyeFocusColliderObjectName]] = CombinedEyeFocusColliderObjectName;
            //HeadData
            header[PositionValueMap[HeadPositionX]] = HeadPositionX;
            header[PositionValueMap[HeadPositionY]] = HeadPositionY;
            header[PositionValueMap[HeadPositionZ]] = HeadPositionZ;
            header[PositionValueMap[HeadRotationX]] = HeadRotationX;
            header[PositionValueMap[HeadRotationY]] = HeadRotationY;
            header[PositionValueMap[HeadRotationZ]] = HeadRotationZ;
            header[PositionValueMap[HeadRotationW]] = HeadRotationW;
            header[PositionValueMap[HeadRotationEularX]] = HeadRotationEularX;
            header[PositionValueMap[HeadRotationEularY]] = HeadRotationEularY;
            header[PositionValueMap[HeadRotationEularZ]] = HeadRotationEularZ;
            header[PositionValueMap[EventHappens]] = EventHappens;

            return header;
        }

        protected override void GenerateBody(List<EyeClopsData> eyeTrackingData, ref List<string[]> serializableData)
        {
            foreach (EyeClopsData data in eyeTrackingData)
            {
                var singleDataLine = new string[PositionValueMap.Count];

                singleDataLine[PositionValueMap[TimeStamp]] = data.Timestamp;

                //LeftEyeData
                singleDataLine[PositionValueMap[LeftEyeDataEyeOriginX]] =
                    data.LeftEyeData.EyeOrigin.x.ToString();
                singleDataLine[PositionValueMap[LeftEyeDataEyeOriginY]] =
                    data.LeftEyeData.EyeOrigin.y.ToString();
                singleDataLine[PositionValueMap[LeftEyeDataEyeOriginZ]] =
                    data.LeftEyeData.EyeOrigin.z.ToString();
                singleDataLine[PositionValueMap[LeftEyeDataNormalizedGazeDirectionX]] =
                    data.LeftEyeData.NormalizedGazeDirection.x.ToString();
                singleDataLine[PositionValueMap[LeftEyeDataNormalizedGazeDirectionY]] =
                    data.LeftEyeData.NormalizedGazeDirection.y.ToString();
                singleDataLine[PositionValueMap[LeftEyeDataNormalizedGazeDirectionZ]] =
                    data.LeftEyeData.NormalizedGazeDirection.z.ToString();
                singleDataLine[PositionValueMap[LeftEyeDataEyeOpeness]] =
                    data.LeftEyeData.EyeOpenness.ToString();
                singleDataLine[PositionValueMap[LeftEyeDataPupilDiameter]] =
                    data.LeftEyeData.PupilDiameter.ToString();
                singleDataLine[PositionValueMap[LeftEyeDataGazeVectorOriginX]] =
                    data.LeftEyeData.GazeVector.origin.x.ToString();
                singleDataLine[PositionValueMap[LeftEyeDataGazeVectorOriginY]] =
                    data.LeftEyeData.GazeVector.origin.y.ToString();
                singleDataLine[PositionValueMap[LeftEyeDataGazeVectorOriginZ]] =
                    data.LeftEyeData.GazeVector.origin.z.ToString();
                singleDataLine[PositionValueMap[LeftEyeDataGazeVectorDirectionX]] =
                    data.LeftEyeData.GazeVector.direction.x.ToString();
                singleDataLine[PositionValueMap[LeftEyeDataGazeVectorDirectionY]] =
                    data.LeftEyeData.GazeVector.direction.y.ToString();
                singleDataLine[PositionValueMap[LeftEyeDataGazeVectorDirectionZ]] =
                    data.LeftEyeData.GazeVector.direction.z.ToString();

                //RightEyeData
                singleDataLine[PositionValueMap[RightEyeDataEyeOriginX]] =
                    data.RightEyeData.EyeOrigin.x.ToString();
                singleDataLine[PositionValueMap[RightEyeDataEyeOriginY]] =
                    data.RightEyeData.EyeOrigin.y.ToString();
                singleDataLine[PositionValueMap[RightEyeDataEyeOriginZ]] =
                    data.RightEyeData.EyeOrigin.z.ToString();
                singleDataLine[PositionValueMap[RightEyeDataNormalizedGazeDirectionX]] =
                    data.RightEyeData.NormalizedGazeDirection.x.ToString();
                singleDataLine[PositionValueMap[RightEyeDataNormalizedGazeDirectionY]] =
                    data.RightEyeData.NormalizedGazeDirection.y.ToString();
                singleDataLine[PositionValueMap[RightEyeDataNormalizedGazeDirectionZ]] =
                    data.RightEyeData.NormalizedGazeDirection.z.ToString();
                singleDataLine[PositionValueMap[RightEyeDataEyeOpeness]] =
                    data.RightEyeData.EyeOpenness.ToString();
                singleDataLine[PositionValueMap[RightEyeDataPupilDiameter]] =
                    data.RightEyeData.PupilDiameter.ToString();
                singleDataLine[PositionValueMap[RightEyeDataGazeVectorOriginX]] =
                    data.RightEyeData.GazeVector.origin.x.ToString();
                singleDataLine[PositionValueMap[RightEyeDataGazeVectorOriginY]] =
                    data.RightEyeData.GazeVector.origin.y.ToString();
                singleDataLine[PositionValueMap[RightEyeDataGazeVectorOriginZ]] =
                    data.RightEyeData.GazeVector.origin.z.ToString();
                singleDataLine[PositionValueMap[RightEyeDataGazeVectorDirectionX]] =
                    data.RightEyeData.GazeVector.direction.x.ToString();
                singleDataLine[PositionValueMap[RightEyeDataGazeVectorDirectionY]] =
                    data.RightEyeData.GazeVector.direction.y.ToString();
                singleDataLine[PositionValueMap[RightEyeDataGazeVectorDirectionZ]] =
                    data.RightEyeData.GazeVector.direction.z.ToString();

                //CombinedEyeData
                singleDataLine[PositionValueMap[CombinedEyeDataConvergenceDistance]] =
                    data.CombinedEyeData.ConvergenceDistance.ToString();
                singleDataLine[PositionValueMap[CombinedEyeDataGazeVectorOriginX]] =
                    data.CombinedEyeData.GazeVector.origin.x.ToString();
                singleDataLine[PositionValueMap[CombinedEyeDataGazeVectorOriginY]] =
                    data.CombinedEyeData.GazeVector.origin.y.ToString();
                singleDataLine[PositionValueMap[CombinedEyeDataGazeVectorOriginZ]] =
                    data.CombinedEyeData.GazeVector.origin.z.ToString();
                singleDataLine[PositionValueMap[CombinedEyeDataGazeVectorDirectionX]] =
                    data.CombinedEyeData.GazeVector.direction.x.ToString();
                singleDataLine[PositionValueMap[CombinedEyeDataGazeVectorDirectionY]] =
                    data.CombinedEyeData.GazeVector.direction.y.ToString();
                singleDataLine[PositionValueMap[CombinedEyeDataGazeVectorDirectionZ]] =
                    data.CombinedEyeData.GazeVector.direction.z.ToString();

                //FocusData
                singleDataLine[PositionValueMap[LeftEyeFocusPositionX]] =
                    data.FocusData.LeftFocusObject.FocusPosition.x.ToString();
                singleDataLine[PositionValueMap[LeftEyeFocusPositionY]] =
                    data.FocusData.LeftFocusObject.FocusPosition.y.ToString();
                singleDataLine[PositionValueMap[LeftEyeFocusPositionZ]] =
                    data.FocusData.LeftFocusObject.FocusPosition.z.ToString();
                singleDataLine[PositionValueMap[LeftEyeFocusObjectName]] =
                    data.FocusData.LeftFocusObject.FocusObjectName;
                singleDataLine[PositionValueMap[LeftEyeFocusColliderObjectName]] =
                    data.FocusData.LeftFocusObject.ObjectColliderName;

                singleDataLine[PositionValueMap[RightEyeFocusPositionX]] =
                    data.FocusData.RightFocusObject.FocusPosition.x.ToString();
                singleDataLine[PositionValueMap[RightEyeFocusPositionY]] =
                    data.FocusData.RightFocusObject.FocusPosition.y.ToString();
                singleDataLine[PositionValueMap[RightEyeFocusPositionZ]] =
                    data.FocusData.RightFocusObject.FocusPosition.z.ToString();
                singleDataLine[PositionValueMap[RightEyeFocusObjectName]] =
                    data.FocusData.RightFocusObject.FocusObjectName;   
                singleDataLine[PositionValueMap[RightEyeFocusColliderObjectName]] =
                    data.FocusData.RightFocusObject.ObjectColliderName;

                singleDataLine[PositionValueMap[CombinedEyeFocusPositionX]] =
                    data.FocusData.CombinedFocusObject.FocusPosition.x.ToString();
                singleDataLine[PositionValueMap[CombinedEyeFocusPositionY]] =
                    data.FocusData.CombinedFocusObject.FocusPosition.y.ToString();
                singleDataLine[PositionValueMap[CombinedEyeFocusPositionZ]] =
                    data.FocusData.CombinedFocusObject.FocusPosition.z.ToString();
                singleDataLine[PositionValueMap[CombinedEyeFocusObjectName]] =
                    data.FocusData.CombinedFocusObject.FocusObjectName;
                singleDataLine[PositionValueMap[CombinedEyeFocusColliderObjectName]] =
                    data.FocusData.CombinedFocusObject.ObjectColliderName;

                //HeadData
                singleDataLine[PositionValueMap[HeadPositionX]] = data.HeadData.HeadPosition.x.ToString();
                singleDataLine[PositionValueMap[HeadPositionY]] = data.HeadData.HeadPosition.y.ToString();
                singleDataLine[PositionValueMap[HeadPositionZ]] = data.HeadData.HeadPosition.z.ToString();
                singleDataLine[PositionValueMap[HeadRotationX]] = data.HeadData.HeadRotation.x.ToString();
                singleDataLine[PositionValueMap[HeadRotationY]] = data.HeadData.HeadRotation.y.ToString();
                singleDataLine[PositionValueMap[HeadRotationZ]] = data.HeadData.HeadRotation.z.ToString();
                singleDataLine[PositionValueMap[HeadRotationW]] = data.HeadData.HeadRotation.w.ToString();
                singleDataLine[PositionValueMap[HeadRotationEularX]] = data.HeadData.HeadRotationEular.x.ToString();
                singleDataLine[PositionValueMap[HeadRotationEularY]] = data.HeadData.HeadRotationEular.y.ToString();
                singleDataLine[PositionValueMap[HeadRotationEularZ]] = data.HeadData.HeadRotationEular.z.ToString();
                singleDataLine[PositionValueMap[EventHappens]] = data.EventData.ToString();

                serializableData.Add(singleDataLine);
            }
        }

        public void DeSerializeEyeTrackingData(List<string[]> csvFile, ref List<EyeClopsData> eyeTrackingData)
        {
            for (int i = 1; i < csvFile.Count; i++)
            {
                string[] csvLine = csvFile[i];
                EyeClopsData newValue = new EyeClopsData
                {
                    Timestamp = csvLine[PositionValueMap[TimeStamp]],
                    LeftEyeData = new SingleEyeData
                    {
                        EyeOrigin = new Vector3(
                            float.Parse(csvLine[PositionValueMap[LeftEyeDataEyeOriginX]]),
                            float.Parse(csvLine[PositionValueMap[LeftEyeDataEyeOriginY]]),
                            float.Parse(csvLine[PositionValueMap[LeftEyeDataEyeOriginZ]])
                        ),
                        NormalizedGazeDirection = new Vector3(
                            float.Parse(csvLine[PositionValueMap[LeftEyeDataNormalizedGazeDirectionX]]),
                            float.Parse(csvLine[PositionValueMap[LeftEyeDataNormalizedGazeDirectionY]]),
                            float.Parse(csvLine[PositionValueMap[LeftEyeDataNormalizedGazeDirectionZ]])
                        ),
                        EyeOpenness = float.Parse(csvLine[PositionValueMap[LeftEyeDataEyeOpeness]]),
                        PupilDiameter = float.Parse(csvLine[PositionValueMap[LeftEyeDataPupilDiameter]]),
                        GazeVector = new Ray(
                            new Vector3(
                                float.Parse(csvLine[PositionValueMap[LeftEyeDataGazeVectorOriginX]]),
                                float.Parse(csvLine[PositionValueMap[LeftEyeDataGazeVectorOriginY]]),
                                float.Parse(csvLine[PositionValueMap[LeftEyeDataGazeVectorOriginZ]])
                            ),
                            new Vector3(
                                float.Parse(csvLine[PositionValueMap[LeftEyeDataGazeVectorDirectionX]]),
                                float.Parse(csvLine[PositionValueMap[LeftEyeDataGazeVectorDirectionY]]),
                                float.Parse(csvLine[PositionValueMap[LeftEyeDataGazeVectorDirectionZ]])
                            )
                        )
                    },
                    RightEyeData = new SingleEyeData
                    {
                        EyeOrigin = new Vector3(
                            float.Parse(csvLine[PositionValueMap[RightEyeDataEyeOriginX]]),
                            float.Parse(csvLine[PositionValueMap[RightEyeDataEyeOriginY]]),
                            float.Parse(csvLine[PositionValueMap[RightEyeDataEyeOriginZ]])
                        ),
                        NormalizedGazeDirection = new Vector3(
                            float.Parse(csvLine[PositionValueMap[RightEyeDataNormalizedGazeDirectionX]]),
                            float.Parse(csvLine[PositionValueMap[RightEyeDataNormalizedGazeDirectionY]]),
                            float.Parse(csvLine[PositionValueMap[RightEyeDataNormalizedGazeDirectionZ]])
                        ),
                        EyeOpenness = float.Parse(csvLine[PositionValueMap[RightEyeDataEyeOpeness]]),
                        PupilDiameter = float.Parse(csvLine[PositionValueMap[RightEyeDataPupilDiameter]]),
                        GazeVector = new Ray(
                            new Vector3(
                                float.Parse(csvLine[PositionValueMap[RightEyeDataGazeVectorOriginX]]),
                                float.Parse(csvLine[PositionValueMap[RightEyeDataGazeVectorOriginY]]),
                                float.Parse(csvLine[PositionValueMap[RightEyeDataGazeVectorOriginZ]])
                            ),
                            new Vector3(
                                float.Parse(csvLine[PositionValueMap[RightEyeDataGazeVectorDirectionX]]),
                                float.Parse(csvLine[PositionValueMap[RightEyeDataGazeVectorDirectionY]]),
                                float.Parse(csvLine[PositionValueMap[RightEyeDataGazeVectorDirectionZ]])
                            )
                        )
                    },
                    CombinedEyeData = new CombinedEyeData
                    {
                        ConvergenceDistance = float.Parse(csvLine[PositionValueMap[CombinedEyeDataConvergenceDistance]]),
                        GazeVector = new Ray(
                            new Vector3(
                                float.Parse(csvLine[PositionValueMap[CombinedEyeDataGazeVectorOriginX]]),
                                float.Parse(csvLine[PositionValueMap[CombinedEyeDataGazeVectorOriginY]]),
                                float.Parse(csvLine[PositionValueMap[CombinedEyeDataGazeVectorOriginZ]])
                            ),
                            new Vector3(
                                float.Parse(csvLine[PositionValueMap[CombinedEyeDataGazeVectorDirectionX]]),
                                float.Parse(csvLine[PositionValueMap[CombinedEyeDataGazeVectorDirectionY]]),
                                float.Parse(csvLine[PositionValueMap[CombinedEyeDataGazeVectorDirectionZ]])
                            )
                        )
                    },
                    FocusData = new FocusData
                    {
                       LeftFocusObject = new FocusObjectInformationData
                        {
                            FocusPosition = new Vector3(
                                float.Parse(csvLine[PositionValueMap[LeftEyeFocusPositionX]]),
                                float.Parse(csvLine[PositionValueMap[LeftEyeFocusPositionY]]),
                                float.Parse(csvLine[PositionValueMap[LeftEyeFocusPositionZ]]) 
                                ),
                            FocusObjectName = csvLine[PositionValueMap[LeftEyeFocusObjectName]],
                            ObjectColliderName = csvLine[PositionValueMap[LeftEyeFocusColliderObjectName]]
                        },
                        
                       RightFocusObject = new FocusObjectInformationData
                       {
                           FocusPosition = new Vector3(
                               float.Parse(csvLine[PositionValueMap[RightEyeFocusPositionX]]),
                               float.Parse(csvLine[PositionValueMap[RightEyeFocusPositionY]]),
                               float.Parse(csvLine[PositionValueMap[RightEyeFocusPositionZ]]) 
                           ),
                           FocusObjectName = csvLine[PositionValueMap[RightEyeFocusObjectName]],
                           ObjectColliderName = csvLine[PositionValueMap[RightEyeFocusColliderObjectName]]
                       },
                       
                       CombinedFocusObject = new FocusObjectInformationData
                       {
                           FocusPosition = new Vector3(
                               float.Parse(csvLine[PositionValueMap[CombinedEyeFocusPositionX]]),
                               float.Parse(csvLine[PositionValueMap[CombinedEyeFocusPositionY]]),
                               float.Parse(csvLine[PositionValueMap[CombinedEyeFocusPositionZ]]) 
                           ),
                           FocusObjectName = csvLine[PositionValueMap[CombinedEyeFocusObjectName]],
                           ObjectColliderName = csvLine[PositionValueMap[CombinedEyeFocusColliderObjectName]]
                       },
                    },
                    HeadData = new HeadData
                    {
                        HeadPosition = new Vector3(
                            float.Parse(csvLine[PositionValueMap[HeadPositionX]]),
                            float.Parse(csvLine[PositionValueMap[HeadPositionY]]),
                            float.Parse(csvLine[PositionValueMap[HeadPositionZ]])
                        ),
                        HeadRotation = new Quaternion(
                            float.Parse(csvLine[PositionValueMap[HeadRotationX]]),
                            float.Parse(csvLine[PositionValueMap[HeadRotationY]]),
                            float.Parse(csvLine[PositionValueMap[HeadRotationZ]]),
                            float.Parse(csvLine[PositionValueMap[HeadRotationW]])
                        ),
                        HeadRotationEular = new Vector3(
                            float.Parse(csvLine[PositionValueMap[HeadRotationEularX]]),
                            float.Parse(csvLine[PositionValueMap[HeadRotationEularY]]),
                            float.Parse(csvLine[PositionValueMap[HeadRotationEularZ]])
                        )
                    },
                    EventData = Boolean.Parse(csvLine[PositionValueMap[EventHappens]])
                };
                eyeTrackingData.Add(newValue);
            }
        }
    }
}