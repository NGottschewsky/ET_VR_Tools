using UnityEngine;
using ViveSR.anipal.Eye;

namespace EyeClops.Data
{
    public struct CustomFocusInfo
    {
        public Vector3 Point;
        public Vector3 Normal;
        public float Distance;
        public string ColliderName;
        public CustomTransform Transform;

        public CustomFocusInfo(FocusInfo focusInfo)
        {
            Point = focusInfo.point;
            Normal = focusInfo.normal;
            Distance = focusInfo.distance;
            ColliderName = focusInfo.collider != null ? focusInfo.collider.name : "";

            Transform = new CustomTransform(focusInfo.transform);
        }
    }
}