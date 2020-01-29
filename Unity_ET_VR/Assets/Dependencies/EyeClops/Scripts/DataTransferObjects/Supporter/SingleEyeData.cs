using UnityEngine;

namespace EyeClops.Data
{
    public struct SingleEyeData 
    {
        public Vector3 EyeOrigin;
        public Vector3 NormalizedGazeDirection;
        public float EyeOpenness;
        public float PupilDiameter;
        public Ray GazeVector;
    }
}
