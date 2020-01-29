using System;
using UnityEngine;

namespace EyeClops.Data
{
    public struct FocusData
    {
        //TODO: Check if FocusInfo not maybe the better replacement for this DataType
        public FocusObjectInformationData LeftFocusObject;
        public FocusObjectInformationData RightFocusObject;
        public FocusObjectInformationData CombinedFocusObject;
//        public Vector3 LeftEyeFocusPosition;
//        public String LeftEyeFocusedObjectName;
//        public Vector3 RightEyeFocusPosition;
//        public String RightEyeFocusedObjectName;
//        public Vector3 CombinedEyeFocusPosition;
//        public String CombinedEyeFocusedObjectName;
    }    
}

