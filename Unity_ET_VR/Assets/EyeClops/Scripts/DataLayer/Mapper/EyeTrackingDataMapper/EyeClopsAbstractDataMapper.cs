using System;
using System.Collections.Generic;
using EyeClops.Data;
using UnityEngine;

namespace EyeClops.DataLayer.Mapper.EyeTrackingDataMapper
{
    public abstract class EyeClopsAbstractDataMapper<Format> : GenericAbstractMapper<EyeClopsData, Format>
    {
        protected readonly Dictionary<string, int> PositionValueMap;

        //MapValues
        protected const string TimeStamp = "TimeStamp";

        //LeftEyeData
        protected const string LeftEyeDataEyeOriginX = "LeftEyeData_EyeOrigin_X";
        protected const string LeftEyeDataEyeOriginY = "LeftEyeData_EyeOrigin_Y";
        protected const string LeftEyeDataEyeOriginZ = "LeftEyeData_EyeOrigin_Z";
        protected const string LeftEyeDataNormalizedGazeDirectionX = "LeftEyeData_NormalizedGazeDirection_X";
        protected const string LeftEyeDataNormalizedGazeDirectionY = "LeftEyeData_NormalizedGazeDirection_Y";
        protected const string LeftEyeDataNormalizedGazeDirectionZ = "LeftEyeData_NormalizedGazeDirection_Z";
        protected const string LeftEyeDataEyeOpeness = "LeftEyeData_EyeOpeness";
        protected const string LeftEyeDataPupilDiameter = "LeftEyeData_PupilDiameter";
        protected const string LeftEyeDataGazeVectorOriginX = "LeftEyeData_GazeVector_Origin_X";
        protected const string LeftEyeDataGazeVectorOriginY = "LeftEyeData_GazeVector_Origin_Y";
        protected const string LeftEyeDataGazeVectorOriginZ = "LeftEyeData_GazeVector_Origin_Z";
        protected const string LeftEyeDataGazeVectorDirectionX = "LeftEyeData_GazeVector_Direction_X";
        protected const string LeftEyeDataGazeVectorDirectionY = "LeftEyeData_GazeVector_Direction_Y";
        protected const string LeftEyeDataGazeVectorDirectionZ = "LeftEyeData_GazeVector_Direction_Z";

        
        
        //RightEyeData
        protected const string RightEyeDataEyeOriginX = "RightEyeData_EyeOrigin_X";
        protected const string RightEyeDataEyeOriginY = "RightEyeData_EyeOrigin_Y";
        protected const string RightEyeDataEyeOriginZ = "RightEyeData_EyeOrigin_Z";
        protected const string RightEyeDataNormalizedGazeDirectionX = "RightEyeData_NormalizedGazeDirection_X";
        protected const string RightEyeDataNormalizedGazeDirectionY = "RightEyeData_NormalizedGazeDirection_Y";
        protected const string RightEyeDataNormalizedGazeDirectionZ = "RightEyeData_NormalizedGazeDirection_Z";
        protected const string RightEyeDataEyeOpeness = "RightEyeData_EyeOpeness";
        protected const string RightEyeDataPupilDiameter = "RightEyeData_PupilDiameter";
        protected const string RightEyeDataGazeVectorOriginX = "RightEyeData_GazeVector_Origin_X";
        protected const string RightEyeDataGazeVectorOriginY = "RightEyeData_GazeVector_Origin_Y";
        protected const string RightEyeDataGazeVectorOriginZ = "RightEyeData_GazeVector_Origin_Z";
        protected const string RightEyeDataGazeVectorDirectionX = "RightEyeData_GazeVector_Direction_X";
        protected const string RightEyeDataGazeVectorDirectionY = "RightEyeData_GazeVector_Direction_Y";
        protected const string RightEyeDataGazeVectorDirectionZ = "RightEyeData_GazeVector_Direction_Z";


        //CombinedEyeData
        protected const string CombinedEyeDataConvergenceDistance = "CombinedEyeData_ConvergenceDistance";
        protected const string CombinedEyeDataGazeVectorOriginX = "CombinedEyeData_GazeVector_Origin_X";
        protected const string CombinedEyeDataGazeVectorOriginY = "CombinedEyeData_GazeVector_Origin_Y";
        protected const string CombinedEyeDataGazeVectorOriginZ = "CombinedEyeData_GazeVector_Origin_Z";
        protected const string CombinedEyeDataGazeVectorDirectionX = "CombinedEyeData_GazeVector_Direction_X";
        protected const string CombinedEyeDataGazeVectorDirectionY = "CombinedEyeData_GazeVector_Direction_Y";
        protected const string CombinedEyeDataGazeVectorDirectionZ = "CombinedEyeData_GazeVector_Direction_Z";

        //FocusData
        protected const string LeftEyeFocusPositionX = "LeftEyeFocusPosition_X";
        protected const string LeftEyeFocusPositionY = "LeftEyeFocusPosition_Y";
        protected const string LeftEyeFocusPositionZ = "LeftEyeFocusPosition_Z";
        protected const string LeftEyeFocusObjectName = "LeftEyeFocusObjectName";
        protected const string LeftEyeFocusColliderObjectName = "LeftEyeFocusColliderObjectName";
        //TODO: Add EyeTracking Left Eye Collider Object HIT
        
        protected const string RightEyeFocusPositionX = "RightEyeFocusPosition_X";
        protected const string RightEyeFocusPositionY = "RightEyeFocusPosition_Y";
        protected const string RightEyeFocusPositionZ = "RightEyeFocusPosition_Z";
        protected const string RightEyeFocusObjectName = "RightEyeFocusObjectName";
        protected const string RightEyeFocusColliderObjectName = "RightEyeFocusColliderObjectName";
        //TODO: Add EyeTracking Right Eye Collider Object HIT
        
        protected const string CombinedEyeFocusPositionX = "CombinedEyeFocusPosition_X";
        protected const string CombinedEyeFocusPositionY = "CombinedEyeFocusPosition_Y";
        protected const string CombinedEyeFocusPositionZ = "CombinedEyeFocusPosition_Z";
        protected const string CombinedEyeFocusObjectName = "CombinedEyeFocusObjectName";
        protected const string CombinedEyeFocusColliderObjectName = "CombinedEyeFocusColliderObjectName";

        //HeadData
        protected const string HeadPositionX = "HeadPosition_X";
        protected const string HeadPositionY = "HeadPosition_Y";
        protected const string HeadPositionZ = "HeadPosition_Z";
        protected const string HeadRotationX = "HeadRotation_X";
        protected const string HeadRotationY = "HeadRotation_Y";
        protected const string HeadRotationZ = "HeadRotation_Z";
        protected const string HeadRotationW = "HeadRotation_ W";
        protected const string HeadRotationEularX = "HeadRotationEular_X";
        protected const string HeadRotationEularY = "HeadRotationEular_Y";
        protected const string HeadRotationEularZ = "HeadRotationEular_Z";

        //EventData
        protected const string EventHappens = "EventHappens";

        protected EyeClopsAbstractDataMapper()
        {
            PositionValueMap = new Dictionary<string, int>
            {
                //MapValues
                {TimeStamp, 0},

                //LeftEyeData
                {LeftEyeDataEyeOriginX, 1},
                {LeftEyeDataEyeOriginY, 2},
                {LeftEyeDataEyeOriginZ, 3},
                {LeftEyeDataNormalizedGazeDirectionX, 4},
                {LeftEyeDataNormalizedGazeDirectionY, 5},
                {LeftEyeDataNormalizedGazeDirectionZ, 6},
                {LeftEyeDataEyeOpeness, 7},
                {LeftEyeDataPupilDiameter, 8},
                {LeftEyeDataGazeVectorOriginX, 9},
                {LeftEyeDataGazeVectorOriginY, 10},
                {LeftEyeDataGazeVectorOriginZ, 11},
                {LeftEyeDataGazeVectorDirectionX, 12},
                {LeftEyeDataGazeVectorDirectionY, 13},
                {LeftEyeDataGazeVectorDirectionZ, 14},

                //RightEyeData
                {RightEyeDataEyeOriginX, 15},
                {RightEyeDataEyeOriginY, 16},
                {RightEyeDataEyeOriginZ, 17},
                {RightEyeDataNormalizedGazeDirectionX, 18},
                {RightEyeDataNormalizedGazeDirectionY, 19},
                {RightEyeDataNormalizedGazeDirectionZ, 20},
                {RightEyeDataEyeOpeness, 21},
                {RightEyeDataPupilDiameter, 22},
                {RightEyeDataGazeVectorOriginX, 23},
                {RightEyeDataGazeVectorOriginY, 24},
                {RightEyeDataGazeVectorOriginZ, 25},
                {RightEyeDataGazeVectorDirectionX, 26},
                {RightEyeDataGazeVectorDirectionY, 27},
                {RightEyeDataGazeVectorDirectionZ, 28},

                //CombinedEyeData
                {CombinedEyeDataConvergenceDistance, 29},
                {CombinedEyeDataGazeVectorOriginX, 30},
                {CombinedEyeDataGazeVectorOriginY, 31},
                {CombinedEyeDataGazeVectorOriginZ, 32},
                {CombinedEyeDataGazeVectorDirectionX, 33},
                {CombinedEyeDataGazeVectorDirectionY, 34},
                {CombinedEyeDataGazeVectorDirectionZ, 35},

                //FocusData
                {LeftEyeFocusPositionX, 36},
                {LeftEyeFocusPositionY, 37},
                {LeftEyeFocusPositionZ, 38},
                {LeftEyeFocusObjectName, 39},
                {LeftEyeFocusColliderObjectName, 40},

                {RightEyeFocusPositionX, 41},
                {RightEyeFocusPositionY, 42},
                {RightEyeFocusPositionZ, 43},
                {RightEyeFocusObjectName, 44},
                {RightEyeFocusColliderObjectName, 45},

                {CombinedEyeFocusPositionX, 46},
                {CombinedEyeFocusPositionY, 47},
                {CombinedEyeFocusPositionZ, 48},
                {CombinedEyeFocusObjectName, 49},
                {CombinedEyeFocusColliderObjectName, 50},

                //HeadData
                {HeadPositionX, 51},
                {HeadPositionY, 52},
                {HeadPositionZ, 53},
                {HeadRotationX, 54},
                {HeadRotationY, 55},
                {HeadRotationZ, 56},
                {HeadRotationW, 57},
                {HeadRotationEularX, 58},
                {HeadRotationEularY, 59},
                {HeadRotationEularZ, 60},
                {EventHappens, 61}
            };
        }
    }
}