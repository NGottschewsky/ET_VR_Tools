using System;
using System.Collections.Generic;
using EyeClops.Data;
using EyeClops.DataLayer.DeSerializer;
using UnityEngine;

namespace EyeClops.DataLayer.Mapper.GazeValidationDataMapper
{
    public class GazeValidationStringDataMapper : GazeValidationAbstractDataMapper
    {
        public List<string[]> GenerateSerializableFormat(
            Dictionary<int, Dictionary<string, List<GazeValidationData>>> gazeValidationData)
        {
            List<string[]> serializableData = new List<string[]> {GenerateHeader()};
            GenerateBody(gazeValidationData, ref serializableData);
            return serializableData;
        }

        private string[] GenerateHeader()
        {
            string[] header = new String[PositionValueMap.Count];
            header[PositionValueMap[PointName]] = PointName;
            header[PositionValueMap[TrailNumber]] = TrailNumber;

            //LeftEye Gaze Validation Data
            header[PositionValueMap[LeftEyeRayOriginX]] = LeftEyeRayOriginX;
            header[PositionValueMap[LeftEyeRayOriginY]] = LeftEyeRayOriginY;
            header[PositionValueMap[LeftEyeRayOriginZ]] = LeftEyeRayOriginZ;
            header[PositionValueMap[LeftEyeRayDirectionX]] = LeftEyeRayDirectionX;
            header[PositionValueMap[LeftEyeRayDirectionY]] = LeftEyeRayDirectionY;
            header[PositionValueMap[LeftEyeRayDirectionZ]] = LeftEyeRayDirectionZ;
            header[PositionValueMap[LeftEyeFocusInfoPointX]] = LeftEyeFocusInfoPointX;
            header[PositionValueMap[LeftEyeFocusInfoPointY]] = LeftEyeFocusInfoPointY;
            header[PositionValueMap[LeftEyeFocusInfoPointZ]] = LeftEyeFocusInfoPointZ;
            header[PositionValueMap[LeftEyeFocusInfoNormalX]] = LeftEyeFocusInfoNormalX;
            header[PositionValueMap[LeftEyeFocusInfoNormalY]] = LeftEyeFocusInfoNormalY;
            header[PositionValueMap[LeftEyeFocusInfoNormalZ]] = LeftEyeFocusInfoNormalZ;
            header[PositionValueMap[LeftEyeFocusInfoDistance]] = LeftEyeFocusInfoDistance;
            header[PositionValueMap[LeftEyeFocusInfoColliderName]] = LeftEyeFocusInfoColliderName;
            header[PositionValueMap[LeftEyeFocusInfoTransformPositionX]] = LeftEyeFocusInfoTransformPositionX;
            header[PositionValueMap[LeftEyeFocusInfoTransformPositionY]] = LeftEyeFocusInfoTransformPositionY;
            header[PositionValueMap[LeftEyeFocusInfoTransformPositionZ]] = LeftEyeFocusInfoTransformPositionZ;
            header[PositionValueMap[LeftEyeFocusInfoTransformEulerAngleX]] = LeftEyeFocusInfoTransformEulerAngleX;
            header[PositionValueMap[LeftEyeFocusInfoTransformEulerAngleY]] = LeftEyeFocusInfoTransformEulerAngleY;
            header[PositionValueMap[LeftEyeFocusInfoTransformEulerAngleZ]] = LeftEyeFocusInfoTransformEulerAngleZ;
            header[PositionValueMap[LeftEyeFocusInfoTransformRotationX]] = LeftEyeFocusInfoTransformRotationX;
            header[PositionValueMap[LeftEyeFocusInfoTransformRotationY]] = LeftEyeFocusInfoTransformRotationY;
            header[PositionValueMap[LeftEyeFocusInfoTransformRotationZ]] = LeftEyeFocusInfoTransformRotationZ;
            header[PositionValueMap[LeftEyeFocusInfoTransformRotationW]] = LeftEyeFocusInfoTransformRotationW;
            header[PositionValueMap[LeftEyeFocusInfoTransformName]] = LeftEyeFocusInfoTransformName;
            header[PositionValueMap[LeftEyeErrorAngle]] = LeftEyeErrorAngle;
            header[PositionValueMap[LeftEyeGroundTruthX]] = LeftEyeGroundTruthX;
            header[PositionValueMap[LeftEyeGroundTruthY]] = LeftEyeGroundTruthY;
            header[PositionValueMap[LeftEyeGroundTruthZ]] = LeftEyeGroundTruthZ;
            header[PositionValueMap[LeftEyeErrorVectorX]] = LeftEyeErrorVectorX;
            header[PositionValueMap[LeftEyeErrorVectorY]] = LeftEyeErrorVectorY;
            header[PositionValueMap[LeftEyeErrorVectorZ]] = LeftEyeErrorVectorZ;

            //RightEye Gaze Validation Data
            header[PositionValueMap[RightEyeRayOriginX]] = RightEyeRayOriginX;
            header[PositionValueMap[RightEyeRayOriginY]] = RightEyeRayOriginY;
            header[PositionValueMap[RightEyeRayOriginZ]] = RightEyeRayOriginZ;
            header[PositionValueMap[RightEyeRayDirectionX]] = RightEyeRayDirectionX;
            header[PositionValueMap[RightEyeRayDirectionY]] = RightEyeRayDirectionY;
            header[PositionValueMap[RightEyeRayDirectionZ]] = RightEyeRayDirectionZ;
            header[PositionValueMap[RightEyeFocusInfoPointX]] = RightEyeFocusInfoPointX;
            header[PositionValueMap[RightEyeFocusInfoPointY]] = RightEyeFocusInfoPointY;
            header[PositionValueMap[RightEyeFocusInfoPointZ]] = RightEyeFocusInfoPointZ;
            header[PositionValueMap[RightEyeFocusInfoNormalX]] = RightEyeFocusInfoNormalX;
            header[PositionValueMap[RightEyeFocusInfoNormalY]] = RightEyeFocusInfoNormalY;
            header[PositionValueMap[RightEyeFocusInfoNormalZ]] = RightEyeFocusInfoNormalZ;
            header[PositionValueMap[RightEyeFocusInfoDistance]] = RightEyeFocusInfoDistance;
            header[PositionValueMap[RightEyeFocusInfoColliderName]] = RightEyeFocusInfoColliderName;
            header[PositionValueMap[RightEyeFocusInfoTransformPositionX]] = RightEyeFocusInfoTransformPositionX;
            header[PositionValueMap[RightEyeFocusInfoTransformPositionY]] = RightEyeFocusInfoTransformPositionY;
            header[PositionValueMap[RightEyeFocusInfoTransformPositionZ]] = RightEyeFocusInfoTransformPositionZ;
            header[PositionValueMap[RightEyeFocusInfoTransformEulerAngleX]] = RightEyeFocusInfoTransformEulerAngleX;
            header[PositionValueMap[RightEyeFocusInfoTransformEulerAngleY]] = RightEyeFocusInfoTransformEulerAngleY;
            header[PositionValueMap[RightEyeFocusInfoTransformEulerAngleZ]] = RightEyeFocusInfoTransformEulerAngleZ;
            header[PositionValueMap[RightEyeFocusInfoTransformRotationX]] = RightEyeFocusInfoTransformRotationX;
            header[PositionValueMap[RightEyeFocusInfoTransformRotationY]] = RightEyeFocusInfoTransformRotationY;
            header[PositionValueMap[RightEyeFocusInfoTransformRotationZ]] = RightEyeFocusInfoTransformRotationZ;
            header[PositionValueMap[RightEyeFocusInfoTransformRotationW]] = RightEyeFocusInfoTransformRotationW;
            header[PositionValueMap[RightEyeFocusInfoTransformName]] = RightEyeFocusInfoTransformName;
            header[PositionValueMap[RightEyeErrorAngle]] = RightEyeErrorAngle;
            header[PositionValueMap[RightEyeGroundTruthX]] = RightEyeGroundTruthX;
            header[PositionValueMap[RightEyeGroundTruthY]] = RightEyeGroundTruthY;
            header[PositionValueMap[RightEyeGroundTruthZ]] = RightEyeGroundTruthZ;
            header[PositionValueMap[RightEyeErrorVectorX]] = RightEyeErrorVectorX;
            header[PositionValueMap[RightEyeErrorVectorY]] = RightEyeErrorVectorY;
            header[PositionValueMap[RightEyeErrorVectorZ]] = RightEyeErrorVectorZ;

            //CombinedEye Gaze Validation Data
            header[PositionValueMap[CombinedEyeRayOriginX]] = CombinedEyeRayOriginX;
            header[PositionValueMap[CombinedEyeRayOriginY]] = CombinedEyeRayOriginY;
            header[PositionValueMap[CombinedEyeRayOriginZ]] = CombinedEyeRayOriginZ;
            header[PositionValueMap[CombinedEyeRayDirectionX]] = CombinedEyeRayDirectionX;
            header[PositionValueMap[CombinedEyeRayDirectionY]] = CombinedEyeRayDirectionY;
            header[PositionValueMap[CombinedEyeRayDirectionZ]] = CombinedEyeRayDirectionZ;
            header[PositionValueMap[CombinedEyeFocusInfoPointX]] = CombinedEyeFocusInfoPointX;
            header[PositionValueMap[CombinedEyeFocusInfoPointY]] = CombinedEyeFocusInfoPointY;
            header[PositionValueMap[CombinedEyeFocusInfoPointZ]] = CombinedEyeFocusInfoPointZ;
            header[PositionValueMap[CombinedEyeFocusInfoNormalX]] = CombinedEyeFocusInfoNormalX;
            header[PositionValueMap[CombinedEyeFocusInfoNormalY]] = CombinedEyeFocusInfoNormalY;
            header[PositionValueMap[CombinedEyeFocusInfoNormalZ]] = CombinedEyeFocusInfoNormalZ;
            header[PositionValueMap[CombinedEyeFocusInfoDistance]] = CombinedEyeFocusInfoDistance;
            header[PositionValueMap[CombinedEyeFocusInfoColliderName]] = CombinedEyeFocusInfoColliderName;
            header[PositionValueMap[CombinedEyeFocusInfoTransformPositionX]] = CombinedEyeFocusInfoTransformPositionX;
            header[PositionValueMap[CombinedEyeFocusInfoTransformPositionY]] = CombinedEyeFocusInfoTransformPositionY;
            header[PositionValueMap[CombinedEyeFocusInfoTransformPositionZ]] = CombinedEyeFocusInfoTransformPositionZ;
            header[PositionValueMap[CombinedEyeFocusInfoTransformEulerAngleX]] = CombinedEyeFocusInfoTransformEulerAngleX;
            header[PositionValueMap[CombinedEyeFocusInfoTransformEulerAngleY]] = CombinedEyeFocusInfoTransformEulerAngleY;
            header[PositionValueMap[CombinedEyeFocusInfoTransformEulerAngleZ]] = CombinedEyeFocusInfoTransformEulerAngleZ;
            header[PositionValueMap[CombinedEyeFocusInfoTransformRotationX]] = CombinedEyeFocusInfoTransformRotationX;
            header[PositionValueMap[CombinedEyeFocusInfoTransformRotationY]] = CombinedEyeFocusInfoTransformRotationY;
            header[PositionValueMap[CombinedEyeFocusInfoTransformRotationZ]] = CombinedEyeFocusInfoTransformRotationZ;
            header[PositionValueMap[CombinedEyeFocusInfoTransformRotationW]] = CombinedEyeFocusInfoTransformRotationW;
            header[PositionValueMap[CombinedEyeFocusInfoTransformName]] = CombinedEyeFocusInfoTransformName;
            header[PositionValueMap[CombinedEyeErrorAngle]] = CombinedEyeErrorAngle;
            header[PositionValueMap[CombinedEyeGroundTruthX]] = CombinedEyeGroundTruthX;
            header[PositionValueMap[CombinedEyeGroundTruthY]] = CombinedEyeGroundTruthY;
            header[PositionValueMap[CombinedEyeGroundTruthZ]] = CombinedEyeGroundTruthZ;
            header[PositionValueMap[CombinedEyeErrorVectorX]] = CombinedEyeErrorVectorX;
            header[PositionValueMap[CombinedEyeErrorVectorY]] = CombinedEyeErrorVectorY;
            header[PositionValueMap[CombinedEyeErrorVectorZ]] = CombinedEyeErrorVectorZ;

            return header;
        }

        private void GenerateBody(Dictionary<int, Dictionary<string, List<GazeValidationData>>> gazeValidationData,
            ref List<string[]> serializableData)
        {
            foreach (KeyValuePair<int, Dictionary<string, List<GazeValidationData>>> trail in gazeValidationData)
            {
                foreach (KeyValuePair<string, List<GazeValidationData>> point in trail.Value)
                {
                    foreach (GazeValidationData validationData in point.Value)
                    {
                        string[] singleDataLine = new String[PositionValueMap.Count];
                        singleDataLine[PositionValueMap[PointName]] = point.Key;
                        singleDataLine[PositionValueMap[TrailNumber]] = trail.Key.ToString();

                        //LeftEye Gaze Validation Data
                        singleDataLine[PositionValueMap[LeftEyeRayOriginX]] =
                            validationData.LeftEyeGazeValidationData.Ray.origin.x.ToString();
                        singleDataLine[PositionValueMap[LeftEyeRayOriginY]] =
                            validationData.LeftEyeGazeValidationData.Ray.origin.y.ToString();
                        singleDataLine[PositionValueMap[LeftEyeRayOriginZ]] =
                            validationData.LeftEyeGazeValidationData.Ray.origin.z.ToString();
                        singleDataLine[PositionValueMap[LeftEyeRayDirectionX]] =
                            validationData.LeftEyeGazeValidationData.Ray.direction.x.ToString();
                        singleDataLine[PositionValueMap[LeftEyeRayDirectionY]] =
                            validationData.LeftEyeGazeValidationData.Ray.direction.y.ToString();
                        singleDataLine[PositionValueMap[LeftEyeRayDirectionZ]] =
                            validationData.LeftEyeGazeValidationData.Ray.direction.z.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoPointX]] =
                            validationData.LeftEyeGazeValidationData.FocusInfo.Point.x.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoPointY]] =
                            validationData.LeftEyeGazeValidationData.FocusInfo.Point.y.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoPointZ]] =
                            validationData.LeftEyeGazeValidationData.FocusInfo.Point.z.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoNormalX]] =
                            validationData.LeftEyeGazeValidationData.FocusInfo.Normal.x.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoNormalY]] =
                            validationData.LeftEyeGazeValidationData.FocusInfo.Normal.y.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoNormalZ]] =
                            validationData.LeftEyeGazeValidationData.FocusInfo.Normal.z.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoDistance]] =
                            validationData.LeftEyeGazeValidationData.FocusInfo.Distance.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoColliderName]] =
                            validationData.LeftEyeGazeValidationData.FocusInfo.ColliderName;
                        var positionLeft = validationData.LeftEyeGazeValidationData.FocusInfo.Transform.Position;
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoTransformPositionX]] = positionLeft.x.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoTransformPositionY]] = positionLeft.y.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoTransformPositionZ]] = positionLeft.z.ToString();
                        var eulerAngleLeft =
                            validationData.LeftEyeGazeValidationData.FocusInfo.Transform.EulerAngles;
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoTransformEulerAngleX]] =
                            eulerAngleLeft.x.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoTransformEulerAngleY]] =
                            eulerAngleLeft.y.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoTransformEulerAngleZ]] =
                            eulerAngleLeft.z.ToString();
                        var rotationLeft = validationData.LeftEyeGazeValidationData.FocusInfo.Transform.Rotation;
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoTransformRotationX]] = rotationLeft.x.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoTransformRotationY]] = rotationLeft.y.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoTransformRotationZ]] = rotationLeft.z.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoTransformRotationW]] = rotationLeft.w.ToString();
                        singleDataLine[PositionValueMap[LeftEyeFocusInfoTransformName]] =
                            validationData.LeftEyeGazeValidationData.FocusInfo.Transform.Name.ToString();
                        singleDataLine[PositionValueMap[LeftEyeErrorAngle]] =
                            validationData.LeftEyeGazeValidationData.ErrorAngle.ToString();
                        singleDataLine[PositionValueMap[LeftEyeGroundTruthX]] =
                            validationData.LeftEyeGazeValidationData.GroundTruth.x.ToString();
                        singleDataLine[PositionValueMap[LeftEyeGroundTruthY]] =
                            validationData.LeftEyeGazeValidationData.GroundTruth.y.ToString();
                        singleDataLine[PositionValueMap[LeftEyeGroundTruthZ]] =
                            validationData.LeftEyeGazeValidationData.GroundTruth.z.ToString();
                        singleDataLine[PositionValueMap[LeftEyeErrorVectorX]] =
                            validationData.LeftEyeGazeValidationData.ErrorVector.x.ToString();
                        singleDataLine[PositionValueMap[LeftEyeErrorVectorY]] =
                            validationData.LeftEyeGazeValidationData.ErrorVector.y.ToString();
                        singleDataLine[PositionValueMap[LeftEyeErrorVectorZ]] =
                            validationData.LeftEyeGazeValidationData.ErrorVector.z.ToString();

                        //RightEye Gaze Validation Data
                        singleDataLine[PositionValueMap[RightEyeRayOriginX]] =
                            validationData.RightEyeGazeValidationData.Ray.origin.x.ToString();
                        singleDataLine[PositionValueMap[RightEyeRayOriginY]] =
                            validationData.RightEyeGazeValidationData.Ray.origin.y.ToString();
                        singleDataLine[PositionValueMap[RightEyeRayOriginZ]] =
                            validationData.RightEyeGazeValidationData.Ray.origin.z.ToString();
                        singleDataLine[PositionValueMap[RightEyeRayDirectionX]] =
                            validationData.RightEyeGazeValidationData.Ray.direction.x.ToString();
                        singleDataLine[PositionValueMap[RightEyeRayDirectionY]] =
                            validationData.RightEyeGazeValidationData.Ray.direction.y.ToString();
                        singleDataLine[PositionValueMap[RightEyeRayDirectionZ]] =
                            validationData.RightEyeGazeValidationData.Ray.direction.z.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoPointX]] =
                            validationData.RightEyeGazeValidationData.FocusInfo.Point.x.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoPointY]] =
                            validationData.RightEyeGazeValidationData.FocusInfo.Point.y.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoPointZ]] =
                            validationData.RightEyeGazeValidationData.FocusInfo.Point.z.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoNormalX]] =
                            validationData.RightEyeGazeValidationData.FocusInfo.Normal.x.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoNormalY]] =
                            validationData.RightEyeGazeValidationData.FocusInfo.Normal.y.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoNormalZ]] =
                            validationData.RightEyeGazeValidationData.FocusInfo.Normal.z.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoDistance]] =
                            validationData.RightEyeGazeValidationData.FocusInfo.Distance.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoColliderName]] =
                            validationData.RightEyeGazeValidationData.FocusInfo.ColliderName;
                        var positionRight = validationData.RightEyeGazeValidationData.FocusInfo.Transform.Position;
                        singleDataLine[PositionValueMap[RightEyeFocusInfoTransformPositionX]] = positionRight.x.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoTransformPositionY]] = positionRight.y.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoTransformPositionZ]] = positionRight.z.ToString();
                        var eulerAngleRight =
                            validationData.RightEyeGazeValidationData.FocusInfo.Transform.EulerAngles;
                        singleDataLine[PositionValueMap[RightEyeFocusInfoTransformEulerAngleX]] =
                            eulerAngleRight.x.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoTransformEulerAngleY]] =
                            eulerAngleRight.y.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoTransformEulerAngleZ]] =
                            eulerAngleRight.z.ToString();

                        var rotationRight = validationData.RightEyeGazeValidationData.FocusInfo.Transform.Rotation;
                        singleDataLine[PositionValueMap[RightEyeFocusInfoTransformRotationX]] = rotationRight.x.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoTransformRotationY]] = rotationRight.y.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoTransformRotationZ]] = rotationRight.z.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoTransformRotationW]] = rotationRight.w.ToString();
                        singleDataLine[PositionValueMap[RightEyeFocusInfoTransformName]] =
                            validationData.RightEyeGazeValidationData.FocusInfo.Transform.Name.ToString();
                        singleDataLine[PositionValueMap[RightEyeErrorAngle]] =
                            validationData.RightEyeGazeValidationData.ErrorAngle.ToString();
                        singleDataLine[PositionValueMap[RightEyeGroundTruthX]] =
                            validationData.RightEyeGazeValidationData.GroundTruth.x.ToString();
                        singleDataLine[PositionValueMap[RightEyeGroundTruthY]] =
                            validationData.RightEyeGazeValidationData.GroundTruth.y.ToString();
                        singleDataLine[PositionValueMap[RightEyeGroundTruthZ]] =
                            validationData.RightEyeGazeValidationData.GroundTruth.z.ToString();
                        singleDataLine[PositionValueMap[RightEyeErrorVectorX]] =
                            validationData.RightEyeGazeValidationData.ErrorVector.x.ToString();
                        singleDataLine[PositionValueMap[RightEyeErrorVectorY]] =
                            validationData.RightEyeGazeValidationData.ErrorVector.y.ToString();
                        singleDataLine[PositionValueMap[RightEyeErrorVectorZ]] =
                            validationData.RightEyeGazeValidationData.ErrorVector.z.ToString();

                        //CombinedEye Gaze Validation Data
                        singleDataLine[PositionValueMap[CombinedEyeRayOriginX]] =
                            validationData.CombinedEyeGazeValidationData.Ray.origin.x.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeRayOriginY]] =
                            validationData.CombinedEyeGazeValidationData.Ray.origin.y.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeRayOriginZ]] =
                            validationData.CombinedEyeGazeValidationData.Ray.origin.z.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeRayDirectionX]] =
                            validationData.CombinedEyeGazeValidationData.Ray.direction.x.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeRayDirectionY]] =
                            validationData.CombinedEyeGazeValidationData.Ray.direction.y.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeRayDirectionZ]] =
                            validationData.CombinedEyeGazeValidationData.Ray.direction.z.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoPointX]] =
                            validationData.CombinedEyeGazeValidationData.FocusInfo.Point.x.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoPointY]] =
                            validationData.CombinedEyeGazeValidationData.FocusInfo.Point.y.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoPointZ]] =
                            validationData.CombinedEyeGazeValidationData.FocusInfo.Point.z.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoNormalX]] =
                            validationData.CombinedEyeGazeValidationData.FocusInfo.Normal.x.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoNormalY]] =
                            validationData.CombinedEyeGazeValidationData.FocusInfo.Normal.y.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoNormalZ]] =
                            validationData.CombinedEyeGazeValidationData.FocusInfo.Normal.z.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoDistance]] =
                            validationData.CombinedEyeGazeValidationData.FocusInfo.Distance.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoColliderName]] =
                            validationData.CombinedEyeGazeValidationData.FocusInfo.ColliderName;
                        var positionCombined = validationData.CombinedEyeGazeValidationData.FocusInfo.Transform.Position;
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoTransformPositionX]] =
                            positionCombined.x.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoTransformPositionY]] =
                            positionCombined.y.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoTransformPositionZ]] =
                            positionCombined.z.ToString();
                        var eulerAngleCombined =
                            validationData.CombinedEyeGazeValidationData.FocusInfo.Transform.EulerAngles;
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoTransformEulerAngleX]] =
                            eulerAngleCombined.x.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoTransformEulerAngleY]] =
                            eulerAngleCombined.y.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoTransformEulerAngleZ]] =
                            eulerAngleCombined.z.ToString();
                        var rotationCombined = validationData.CombinedEyeGazeValidationData.FocusInfo.Transform.Rotation;
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoTransformRotationX]] =
                            rotationCombined.x.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoTransformRotationY]] =
                            rotationCombined.y.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoTransformRotationZ]] =
                            rotationCombined.z.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoTransformRotationW]] =
                            rotationCombined.w.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeFocusInfoTransformName]] =
                            validationData.CombinedEyeGazeValidationData.FocusInfo.Transform.Name.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeErrorAngle]] =
                            validationData.CombinedEyeGazeValidationData.ErrorAngle.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeGroundTruthX]] =
                            validationData.CombinedEyeGazeValidationData.GroundTruth.x.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeGroundTruthY]] =
                            validationData.CombinedEyeGazeValidationData.GroundTruth.y.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeGroundTruthZ]] =
                            validationData.CombinedEyeGazeValidationData.GroundTruth.z.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeErrorVectorX]] =
                            validationData.CombinedEyeGazeValidationData.ErrorVector.x.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeErrorVectorY]] =
                            validationData.CombinedEyeGazeValidationData.ErrorVector.y.ToString();
                        singleDataLine[PositionValueMap[CombinedEyeErrorVectorZ]] =
                            validationData.CombinedEyeGazeValidationData.ErrorVector.z.ToString();

                        serializableData.Add(singleDataLine);
                    }
                }
            }
        }

        public void DeSerializeGazeValidationData(List<string[]> csvFile,
            ref Dictionary<int, Dictionary<string, List<GazeValidationData>>> allDataOverAllTrails)
        {
            //Liste mit allen einträgen als wrapper klasse, diese enthält selbst den punktnamen und die trailnummer
            List<InnerWrapperGazeValidationData> wrappedGazeValidationData = new List<InnerWrapperGazeValidationData>();

            //Skiped the first line, because this is the header!
            for (int i = 1; i < csvFile.Count; i++)
            {
                string[] singleLine = csvFile[i];

                wrappedGazeValidationData.Add(new InnerWrapperGazeValidationData(
                    singleLine[PositionValueMap[PointName]],
                    int.Parse(singleLine[PositionValueMap[TrailNumber]]),

                    //LeftEye
                    new Ray(
                        new Vector3(
                            float.Parse(singleLine[PositionValueMap[LeftEyeRayOriginX]]),
                            float.Parse(singleLine[PositionValueMap[LeftEyeRayOriginY]]),
                            float.Parse(singleLine[PositionValueMap[LeftEyeRayOriginZ]])
                        ),
                        new Vector3(
                            float.Parse(singleLine[PositionValueMap[LeftEyeRayDirectionX]]),
                            float.Parse(singleLine[PositionValueMap[LeftEyeRayDirectionY]]),
                            float.Parse(singleLine[PositionValueMap[LeftEyeRayDirectionZ]])
                        )
                    ),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoPointX]]),
                        float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoPointY]]),
                        float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoPointZ]])
                    ),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoNormalX]]),
                        float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoNormalY]]),
                        float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoNormalZ]])
                    ),
                    float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoDistance]]),
                                        singleLine[PositionValueMap[LeftEyeFocusInfoColliderName]],
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoTransformPositionX]]),
                        float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoTransformPositionY]]),
                        float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoTransformPositionZ]])
                    ),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoTransformEulerAngleX]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoTransformEulerAngleY]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoTransformEulerAngleZ]])
                    ),
                    new Quaternion(
                        float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoTransformRotationX]]),
                        float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoTransformRotationY]]),
                        float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoTransformRotationZ]]),
                        float.Parse(singleLine[PositionValueMap[LeftEyeFocusInfoTransformRotationW]])
                    ),
                    singleLine[PositionValueMap[LeftEyeFocusInfoTransformName]].ToString(),
                    float.Parse(singleLine[PositionValueMap[LeftEyeErrorAngle]]),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[LeftEyeGroundTruthX]]),
                        float.Parse(singleLine[PositionValueMap[LeftEyeGroundTruthY]]),
                        float.Parse(singleLine[PositionValueMap[LeftEyeGroundTruthZ]])
                    ),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[LeftEyeErrorVectorX]]),
                        float.Parse(singleLine[PositionValueMap[LeftEyeErrorVectorY]]),
                        float.Parse(singleLine[PositionValueMap[LeftEyeErrorVectorZ]])
                    ),

                    //RightEye
                    new Ray(
                        new Vector3(
                            float.Parse(singleLine[PositionValueMap[RightEyeRayOriginX]]),
                            float.Parse(singleLine[PositionValueMap[RightEyeRayOriginY]]),
                            float.Parse(singleLine[PositionValueMap[RightEyeRayOriginZ]])
                        ),
                        new Vector3(
                            float.Parse(singleLine[PositionValueMap[RightEyeRayDirectionX]]),
                            float.Parse(singleLine[PositionValueMap[RightEyeRayDirectionY]]),
                            float.Parse(singleLine[PositionValueMap[RightEyeRayDirectionZ]])
                        )
                    ),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoPointX]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoPointY]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoPointZ]])
                    ),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoNormalX]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoNormalY]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoNormalZ]])
                    ),
                    float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoDistance]]),
                    singleLine[PositionValueMap[RightEyeFocusInfoColliderName]],
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoTransformPositionX]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoTransformPositionY]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoTransformPositionZ]])
                    ),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoTransformEulerAngleX]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoTransformEulerAngleY]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoTransformEulerAngleZ]])
                    ),
                    new Quaternion(
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoTransformRotationX]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoTransformRotationY]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoTransformRotationZ]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeFocusInfoTransformRotationW]])
                    ),
                    singleLine[PositionValueMap[RightEyeFocusInfoTransformName]].ToString(),
                    float.Parse(singleLine[PositionValueMap[RightEyeErrorAngle]]),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[RightEyeGroundTruthX]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeGroundTruthY]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeGroundTruthZ]])
                    ),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[RightEyeErrorVectorX]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeErrorVectorY]]),
                        float.Parse(singleLine[PositionValueMap[RightEyeErrorVectorZ]])
                    ),

                    //CombinedEye
                    new Ray(
                        new Vector3(
                            float.Parse(singleLine[PositionValueMap[CombinedEyeRayOriginX]]),
                            float.Parse(singleLine[PositionValueMap[CombinedEyeRayOriginY]]),
                            float.Parse(singleLine[PositionValueMap[CombinedEyeRayOriginZ]])
                        ),
                        new Vector3(
                            float.Parse(singleLine[PositionValueMap[CombinedEyeRayDirectionX]]),
                            float.Parse(singleLine[PositionValueMap[CombinedEyeRayDirectionY]]),
                            float.Parse(singleLine[PositionValueMap[CombinedEyeRayDirectionZ]])
                        )
                    ),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoPointX]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoPointY]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoPointZ]])
                    ),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoNormalX]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoNormalY]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoNormalZ]])
                    ),
                    float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoDistance]]),
                    singleLine[PositionValueMap[CombinedEyeFocusInfoColliderName]],
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoTransformPositionX]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoTransformPositionY]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoTransformPositionZ]])
                    ),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoTransformEulerAngleX]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoTransformEulerAngleY]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoTransformEulerAngleZ]])
                    ),
                    new Quaternion(
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoTransformRotationX]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoTransformRotationY]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoTransformRotationZ]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeFocusInfoTransformRotationW]])
                    ),
                    singleLine[PositionValueMap[CombinedEyeFocusInfoTransformName]].ToString(),
                    float.Parse(singleLine[PositionValueMap[CombinedEyeErrorAngle]]),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[CombinedEyeGroundTruthX]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeGroundTruthY]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeGroundTruthZ]])
                    ),
                    new Vector3(
                        float.Parse(singleLine[PositionValueMap[CombinedEyeErrorVectorX]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeErrorVectorY]]),
                        float.Parse(singleLine[PositionValueMap[CombinedEyeErrorVectorZ]])
                    )
                ));
            }


            List<string> allPointNames = new List<string>();
            List<int> allTryNumbers = new List<int>();
            foreach (InnerWrapperGazeValidationData wrappedData in wrappedGazeValidationData)
            {
                if (!allPointNames.Contains(wrappedData.PointName))
                {
                    allPointNames.Add(wrappedData.PointName);
                }

                if (!allTryNumbers.Contains(wrappedData.TryNumber))
                {
                    allTryNumbers.Add(wrappedData.TryNumber);
                }
            }


            foreach (int tryNumber in allTryNumbers)
            {
                Dictionary<string, List<GazeValidationData>> allPointsToTry =
                    new Dictionary<string, List<GazeValidationData>>();
                foreach (string pointName in allPointNames)
                {
                    List<GazeValidationData> allGazeValidationDataToPoint = new List<GazeValidationData>();
                    foreach (InnerWrapperGazeValidationData wrappedData in wrappedGazeValidationData)
                    {
                        if (wrappedData.PointName.Equals(pointName) && wrappedData.TryNumber == tryNumber)
                        {
                            allGazeValidationDataToPoint.Add(new GazeValidationData(
                                wrappedData.LeftEyeGaze,
                                wrappedData.RightEyeGaze,
                                wrappedData.CombinedEyeGaze
                            ));
                        }
                    }

                    allPointsToTry.Add(pointName, allGazeValidationDataToPoint);
                }

                allDataOverAllTrails.Add(tryNumber, allPointsToTry);
            }
        }

        private class InnerWrapperGazeValidationData
        {
            public readonly string PointName;
            public readonly int TryNumber;

            public readonly SpecificGazeValidationData LeftEyeGaze;
            public readonly SpecificGazeValidationData RightEyeGaze;
            public readonly SpecificGazeValidationData CombinedEyeGaze;

            public InnerWrapperGazeValidationData(
                string pointName,
                int tryNumber, 
                Ray leftEyeRay,
                Vector3 leftEyeFocusInfoPoint,
                Vector3 leftEyeFocusInfoNormal,
                float leftEyeFocusInfoDistance,
                String leftEyeFocusInfoColliderName,
                Vector3 leftEyeFocusInfoTransformPosition,
                Vector3 leftEyeFocusInfoTransformEulerangle,
                Quaternion leftEyeFocusInfoTransformRotation,
                string leftEyeFocusInfoTransformName,
                float leftEyeErrorAngle,
                Vector3 leftEyeGroundTruth,
                Vector3 leftEyeErrorVector,
                Ray rightEyeRay,
                Vector3 rightEyeFocusInfoPoint,
                Vector3 rightEyeFocusInfoNormal,
                float rightEyeFocusInfoDistance,
                string rightEyeFocusInfoColliderName,
                Vector3 rightEyeFocusInfoTransformPosition,
                Vector3 rightEyeFocusInfoTransformEulerangle,
                Quaternion rightEyeFocusInfoTransformRotation,
                string rightEyeFocusInfoTransformName,
                float rightEyeErrorAngle,
                Vector3 rightEyeGroundTruth,
                Vector3 rightEyeErrorVector,
                Ray combinedEyeRay,
                Vector3 combinedEyeFocusInfoPoint,
                Vector3 combinedEyeFocusInfoNormal,
                float combinedEyeFocusInfoDistance,
                string combinedEyeFocusInfoColliderName,
                Vector3 combinedEyeFocusInfoTransformPosition,
                Vector3 combinedEyeFocusInfoTransformEulerangle,
                Quaternion combinedEyeFocusInfoTransformRotation,
                string combinedEyeFocusInfoTransformName,
                float combinedEyeErrorAngle,
                Vector3 combinedEyeGroundTruth,
                Vector3 combinedEyeErrorVector
            )
            {
                this.PointName = pointName;
                this.TryNumber = tryNumber;
                var helperFocusInfoLeftEye = new CustomFocusInfo
                {
                    Point = leftEyeFocusInfoPoint,
                    Normal = leftEyeFocusInfoNormal,
                    Distance = leftEyeFocusInfoDistance,
                    ColliderName = leftEyeFocusInfoColliderName,
                    Transform = new CustomTransform
                    {
                        Position = leftEyeFocusInfoTransformPosition,
                        EulerAngles = leftEyeFocusInfoTransformEulerangle,
                        Rotation = leftEyeFocusInfoTransformRotation,
                        Name = leftEyeFocusInfoTransformName
                    }
                };
                this.LeftEyeGaze = new SpecificGazeValidationData(
                    leftEyeRay,
                    helperFocusInfoLeftEye,
                    leftEyeErrorAngle,
                    leftEyeGroundTruth,
                    leftEyeErrorVector
                );
                var helperFocusInfoRightEye = new CustomFocusInfo
                {
                    Point = rightEyeFocusInfoPoint,
                    Normal = rightEyeFocusInfoNormal,
                    Distance = rightEyeFocusInfoDistance,
                    ColliderName = rightEyeFocusInfoColliderName,
                    Transform = new CustomTransform
                    {
                        Position = rightEyeFocusInfoTransformPosition,
                        EulerAngles = rightEyeFocusInfoTransformEulerangle,
                        Rotation = rightEyeFocusInfoTransformRotation,
                        Name = rightEyeFocusInfoTransformName
                    }
                };
                this.RightEyeGaze = new SpecificGazeValidationData(
                    rightEyeRay,
                    helperFocusInfoRightEye,
                    rightEyeErrorAngle,
                    rightEyeGroundTruth,
                    rightEyeErrorVector
                );
                var helperFocusInfoCombinedEye = new CustomFocusInfo
                {
                    Point = combinedEyeFocusInfoPoint,
                    Normal = combinedEyeFocusInfoNormal,
                    Distance = combinedEyeFocusInfoDistance,
                    ColliderName = combinedEyeFocusInfoColliderName,
                    Transform = new CustomTransform
                    {
                        Position = combinedEyeFocusInfoTransformPosition,
                        EulerAngles = combinedEyeFocusInfoTransformEulerangle,
                        Rotation = combinedEyeFocusInfoTransformRotation,
                        Name = combinedEyeFocusInfoTransformName
                    }
                };
                this.CombinedEyeGaze = new SpecificGazeValidationData(
                    combinedEyeRay,
                    helperFocusInfoCombinedEye,
                    combinedEyeErrorAngle,
                    combinedEyeGroundTruth,
                    combinedEyeErrorVector
                );
            }
        }
    }
}