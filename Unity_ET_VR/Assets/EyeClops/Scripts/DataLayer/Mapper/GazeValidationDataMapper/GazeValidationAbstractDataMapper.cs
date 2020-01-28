using System;
using System.Collections.Generic;
using EyeClops.Data;
namespace EyeClops.DataLayer.Mapper.GazeValidationDataMapper
{
    public abstract class GazeValidationAbstractDataMapper
    {
        protected readonly Dictionary<string, int> PositionValueMap;

        protected const string PointName = "Point_Name";
        protected const string TrailNumber = "Trail_Number";

        //LeftEye Gaze Validation Data
        protected const string LeftEyeRayOriginX = "LeftEye_Ray_origin_x";
        protected const string LeftEyeRayOriginY = "LeftEye_Ray_origin_y";
        protected const string LeftEyeRayOriginZ = "LeftEye_Ray_origin_z";
        protected const string LeftEyeRayDirectionX = "LeftEye_Ray_direction_x";
        protected const string LeftEyeRayDirectionY = "LeftEye_Ray_direction_y";
        protected const string LeftEyeRayDirectionZ = "LeftEye_Ray_direction_z";
        protected const string LeftEyeFocusInfoPointX = "LeftEye_FocusInfo_Point_x";
        protected const string LeftEyeFocusInfoPointY = "LeftEye_FocusInfo_Point_y";
        protected const string LeftEyeFocusInfoPointZ = "LeftEye_FocusInfo_Point_z";
        protected const string LeftEyeFocusInfoNormalX = "LeftEye_FocusInfo_Normal_x";
        protected const string LeftEyeFocusInfoNormalY = "LeftEye_FocusInfo_Normal_y";
        protected const string LeftEyeFocusInfoNormalZ = "LeftEye_FocusInfo_Normal_z";
        protected const string LeftEyeFocusInfoDistance = "LeftEye_FocusInfo_Distance";
        protected const string LeftEyeFocusInfoColliderName = "LeftEye_FocusInfo_Collider_Name";
        protected const string LeftEyeFocusInfoTransformPositionX = "LeftEye_FocusInfo_Transform_Position_x";
        protected const string LeftEyeFocusInfoTransformPositionY = "LeftEye_FocusInfo_Transform_Position_y";
        protected const string LeftEyeFocusInfoTransformPositionZ = "LeftEye_FocusInfo_Transform_Position_z";
        protected const string LeftEyeFocusInfoTransformEulerAngleX = "LeftEye_FocusInfo_Transform_EulerAngle_x";
        protected const string LeftEyeFocusInfoTransformEulerAngleY = "LeftEye_FocusInfo_Transform_EulerAngle_y";
        protected const string LeftEyeFocusInfoTransformEulerAngleZ = "LeftEye_FocusInfo_Transform_EulerAngle_z";
        protected const string LeftEyeFocusInfoTransformRotationX = "LeftEye_FocusInfo_Transform_Rotation_x";
        protected const string LeftEyeFocusInfoTransformRotationY = "LeftEye_FocusInfo_Transform_Rotation_y";
        protected const string LeftEyeFocusInfoTransformRotationZ = "LeftEye_FocusInfo_Transform_Rotation_z";
        protected const string LeftEyeFocusInfoTransformRotationW = "LeftEye_FocusInfo_Transform_Rotation_w";
        protected const string LeftEyeFocusInfoTransformName = "LeftEye_FocusInfo_Transform_Name";
        protected const string LeftEyeErrorAngle = "LeftEye_ErrorAngle";
        protected const string LeftEyeGroundTruthX = "LeftEye_GroundTruth_x";
        protected const string LeftEyeGroundTruthY = "LeftEye_GroundTruth_y";
        protected const string LeftEyeGroundTruthZ = "LeftEye_GroundTruth_z";
        protected const string LeftEyeErrorVectorX = "LeftEye_ErrorVector_x";
        protected const string LeftEyeErrorVectorY = "LeftEye_ErrorVector_y";
        protected const string LeftEyeErrorVectorZ = "LeftEye_ErrorVector_z";

        //RightEye Gaze Validation Data
        protected const string RightEyeRayOriginX = "RightEye_Ray_origin_x";
        protected const string RightEyeRayOriginY = "RightEye_Ray_origin_y";
        protected const string RightEyeRayOriginZ = "RightEye_Ray_origin_z";
        protected const string RightEyeRayDirectionX = "RightEye_Ray_direction_x";
        protected const string RightEyeRayDirectionY = "RightEye_Ray_direction_y";
        protected const string RightEyeRayDirectionZ = "RightEye_Ray_direction_z";
        protected const string RightEyeFocusInfoPointX = "RightEye_FocusInfo_Point_x";
        protected const string RightEyeFocusInfoPointY = "RightEye_FocusInfo_Point_y";
        protected const string RightEyeFocusInfoPointZ = "RightEye_FocusInfo_Point_z";
        protected const string RightEyeFocusInfoNormalX = "RightEye_FocusInfo_Normal_x";
        protected const string RightEyeFocusInfoNormalY = "RightEye_FocusInfo_Normal_y";
        protected const string RightEyeFocusInfoNormalZ = "RightEye_FocusInfo_Normal_z";
        protected const string RightEyeFocusInfoDistance = "RightEye_FocusInfo_Distance";
        protected const string RightEyeFocusInfoColliderName = "RightEye_FocusInfo_Collider_Name";
        protected const string RightEyeFocusInfoTransformPositionX = "RightEye_FocusInfo_Transform_Position_x";
        protected const string RightEyeFocusInfoTransformPositionY = "RightEye_FocusInfo_Transform_Position_y";
        protected const string RightEyeFocusInfoTransformPositionZ = "RightEye_FocusInfo_Transform_Position_z";
        protected const string RightEyeFocusInfoTransformEulerAngleX = "RightEye_FocusInfo_Transform_EulerAngle_x";
        protected const string RightEyeFocusInfoTransformEulerAngleY = "RightEye_FocusInfo_Transform_EulerAngle_y";
        protected const string RightEyeFocusInfoTransformEulerAngleZ = "RightEye_FocusInfo_Transform_EulerAngle_z";
        protected const string RightEyeFocusInfoTransformRotationX = "RightEye_FocusInfo_Transform_Rotation_x";
        protected const string RightEyeFocusInfoTransformRotationY = "RightEye_FocusInfo_Transform_Rotation_y";
        protected const string RightEyeFocusInfoTransformRotationZ = "RightEye_FocusInfo_Transform_Rotation_z";
        protected const string RightEyeFocusInfoTransformRotationW = "RightEye_FocusInfo_Transform_Rotation_w";
        protected const string RightEyeFocusInfoTransformName = "RightEye_FocusInfo_Transform_Name";
        protected const string RightEyeErrorAngle = "RightEye_ErrorAngle";
        protected const string RightEyeGroundTruthX = "RightEye_GroundTruth_x";
        protected const string RightEyeGroundTruthY = "RightEye_GroundTruth_y";
        protected const string RightEyeGroundTruthZ = "RightEye_GroundTruth_z";
        protected const string RightEyeErrorVectorX = "RightEye_ErrorVector_x";
        protected const string RightEyeErrorVectorY = "RightEye_ErrorVector_y";
        protected const string RightEyeErrorVectorZ = "RightEye_ErrorVector_z";

        //CombinedEye Gaze Validation Data
        protected const string CombinedEyeRayOriginX = "CombinedEye_Ray_origin_x";
        protected const string CombinedEyeRayOriginY = "CombinedEye_Ray_origin_y";
        protected const string CombinedEyeRayOriginZ = "CombinedEye_Ray_origin_z";
        protected const string CombinedEyeRayDirectionX = "CombinedEye_Ray_direction_x";
        protected const string CombinedEyeRayDirectionY = "CombinedEye_Ray_direction_y";
        protected const string CombinedEyeRayDirectionZ = "CombinedEye_Ray_direction_z";
        protected const string CombinedEyeFocusInfoPointX = "CombinedEye_FocusInfo_Point_x";
        protected const string CombinedEyeFocusInfoPointY = "CombinedEye_FocusInfo_Point_y";
        protected const string CombinedEyeFocusInfoPointZ = "CombinedEye_FocusInfo_Point_z";
        protected const string CombinedEyeFocusInfoNormalX = "CombinedEye_FocusInfo_Normal_x";
        protected const string CombinedEyeFocusInfoNormalY = "CombinedEye_FocusInfo_Normal_y";
        protected const string CombinedEyeFocusInfoNormalZ = "CombinedEye_FocusInfo_Normal_z";
        protected const string CombinedEyeFocusInfoDistance = "CombinedEye_FocusInfo_Distance";
        protected const string CombinedEyeFocusInfoColliderName = "CombinedEye_FocusInfo_Collider_Name";
        protected const string CombinedEyeFocusInfoTransformPositionX = "CombinedEye_FocusInfo_Transform_Position_x";
        protected const string CombinedEyeFocusInfoTransformPositionY = "CombinedEye_FocusInfo_Transform_Position_y";
        protected const string CombinedEyeFocusInfoTransformPositionZ = "CombinedEye_FocusInfo_Transform_Position_z";
        protected const string CombinedEyeFocusInfoTransformEulerAngleX = "CombinedEye_FocusInfo_Transform_EulerAngle_x";
        protected const string CombinedEyeFocusInfoTransformEulerAngleY = "CombinedEye_FocusInfo_Transform_EulerAngle_y";
        protected const string CombinedEyeFocusInfoTransformEulerAngleZ = "CombinedEye_FocusInfo_Transform_EulerAngle_z";
        protected const string CombinedEyeFocusInfoTransformRotationX = "CombinedEye_FocusInfo_Transform_Rotation_x";
        protected const string CombinedEyeFocusInfoTransformRotationY = "CombinedEye_FocusInfo_Transform_Rotation_y";
        protected const string CombinedEyeFocusInfoTransformRotationZ = "CombinedEye_FocusInfo_Transform_Rotation_z";
        protected const string CombinedEyeFocusInfoTransformRotationW = "CombinedEye_FocusInfo_Transform_Rotation_w";
        protected const string CombinedEyeFocusInfoTransformName = "CombinedEye_FocusInfo_Transform_Name";
        protected const string CombinedEyeErrorAngle = "CombinedEye_ErrorAngle";
        protected const string CombinedEyeGroundTruthX = "CombinedEye_GroundTruth_x";
        protected const string CombinedEyeGroundTruthY = "CombinedEye_GroundTruth_y";
        protected const string CombinedEyeGroundTruthZ = "CombinedEye_GroundTruth_z";
        protected const string CombinedEyeErrorVectorX = "CombinedEye_ErrorVector_x";
        protected const string CombinedEyeErrorVectorY = "CombinedEye_ErrorVector_y";
        protected const string CombinedEyeErrorVectorZ = "CombinedEye_ErrorVector_z";


        protected GazeValidationAbstractDataMapper()
        {
            PositionValueMap = new Dictionary<string, int>
            {
                //Identifier
                {PointName, 0},
                {TrailNumber, 1},

                //LeftEye Gaze Validation Data
                {LeftEyeRayOriginX, 2},
                {LeftEyeRayOriginY, 3},
                {LeftEyeRayOriginZ, 4},
                {LeftEyeRayDirectionX, 5},
                {LeftEyeRayDirectionY, 6},
                {LeftEyeRayDirectionZ, 7},
                {LeftEyeFocusInfoPointX, 8},
                {LeftEyeFocusInfoPointY, 9},
                {LeftEyeFocusInfoPointZ, 10},
                {LeftEyeFocusInfoNormalX, 11},
                {LeftEyeFocusInfoNormalY, 12},
                {LeftEyeFocusInfoNormalZ, 13},
                {LeftEyeFocusInfoDistance, 14},
                {LeftEyeFocusInfoColliderName, 15},
                {LeftEyeFocusInfoTransformPositionX, 16},
                {LeftEyeFocusInfoTransformPositionY, 17},
                {LeftEyeFocusInfoTransformPositionZ, 18},
                {LeftEyeFocusInfoTransformEulerAngleX, 19},
                {LeftEyeFocusInfoTransformEulerAngleY, 20},
                {LeftEyeFocusInfoTransformEulerAngleZ, 21},
                {LeftEyeFocusInfoTransformRotationX, 22},
                {LeftEyeFocusInfoTransformRotationY, 23},
                {LeftEyeFocusInfoTransformRotationZ, 24},
                {LeftEyeFocusInfoTransformRotationW, 25},
                {LeftEyeFocusInfoTransformName, 26},
                {LeftEyeErrorAngle, 27},
                {LeftEyeGroundTruthX, 28},
                {LeftEyeGroundTruthY, 29},
                {LeftEyeGroundTruthZ, 30},
                {LeftEyeErrorVectorX, 31},
                {LeftEyeErrorVectorY, 32},
                {LeftEyeErrorVectorZ, 33},

                //RightEye Gaze Validation Data
                {RightEyeRayOriginX, 34},
                {RightEyeRayOriginY, 35},
                {RightEyeRayOriginZ, 36},
                {RightEyeRayDirectionX, 37},
                {RightEyeRayDirectionY, 38},
                {RightEyeRayDirectionZ, 39},
                {RightEyeFocusInfoPointX, 40},
                {RightEyeFocusInfoPointY, 41},
                {RightEyeFocusInfoPointZ, 42},
                {RightEyeFocusInfoNormalX, 43},
                {RightEyeFocusInfoNormalY, 44},
                {RightEyeFocusInfoNormalZ, 45},
                {RightEyeFocusInfoDistance, 46},
                {RightEyeFocusInfoColliderName, 47},
                {RightEyeFocusInfoTransformPositionX, 48},
                {RightEyeFocusInfoTransformPositionY, 49},
                {RightEyeFocusInfoTransformPositionZ, 50},
                {RightEyeFocusInfoTransformEulerAngleX, 51},
                {RightEyeFocusInfoTransformEulerAngleY, 52},
                {RightEyeFocusInfoTransformEulerAngleZ, 53},
                {RightEyeFocusInfoTransformRotationX, 54},
                {RightEyeFocusInfoTransformRotationY, 55},
                {RightEyeFocusInfoTransformRotationZ, 56},
                {RightEyeFocusInfoTransformRotationW, 57},
                {RightEyeFocusInfoTransformName, 58},
                {RightEyeErrorAngle, 59},
                {RightEyeGroundTruthX, 60},
                {RightEyeGroundTruthY, 61},
                {RightEyeGroundTruthZ, 62},
                {RightEyeErrorVectorX, 63},
                {RightEyeErrorVectorY, 64},
                {RightEyeErrorVectorZ, 65},

                //CombinedEye Gaze Validation Data
                {CombinedEyeRayOriginX, 66},
                {CombinedEyeRayOriginY, 67},
                {CombinedEyeRayOriginZ, 68},
                {CombinedEyeRayDirectionX, 69},
                {CombinedEyeRayDirectionY, 70},
                {CombinedEyeRayDirectionZ, 71},
                {CombinedEyeFocusInfoPointX, 72},
                {CombinedEyeFocusInfoPointY, 73},
                {CombinedEyeFocusInfoPointZ, 74},
                {CombinedEyeFocusInfoNormalX, 75},
                {CombinedEyeFocusInfoNormalY, 76},
                {CombinedEyeFocusInfoNormalZ, 77},
                {CombinedEyeFocusInfoDistance, 78},
                {CombinedEyeFocusInfoColliderName, 79},
                {CombinedEyeFocusInfoTransformPositionX, 80},
                {CombinedEyeFocusInfoTransformPositionY, 81},
                {CombinedEyeFocusInfoTransformPositionZ, 82},
                {CombinedEyeFocusInfoTransformEulerAngleX, 83},
                {CombinedEyeFocusInfoTransformEulerAngleY, 84},
                {CombinedEyeFocusInfoTransformEulerAngleZ, 85},
                {CombinedEyeFocusInfoTransformRotationX, 86},
                {CombinedEyeFocusInfoTransformRotationY, 87},
                {CombinedEyeFocusInfoTransformRotationZ, 88},
                {CombinedEyeFocusInfoTransformRotationW, 89},
                {CombinedEyeFocusInfoTransformName, 90},
                {CombinedEyeErrorAngle, 91},
                {CombinedEyeGroundTruthX, 92},
                {CombinedEyeGroundTruthY, 93},
                {CombinedEyeGroundTruthZ, 94},
                {CombinedEyeErrorVectorX, 95},
                {CombinedEyeErrorVectorY, 96},
                {CombinedEyeErrorVectorZ, 97}
            };
        }
    }
}