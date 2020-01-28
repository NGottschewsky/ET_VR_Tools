using UnityEngine;

namespace EyeClops.Data
{
    public class CustomTransform
    {
        public Vector3 Position;
        public Vector3 EulerAngles;
        public Quaternion Rotation;
        public string Name;

        public CustomTransform()
        {
        }

        public CustomTransform(Transform generateTransform)
        {
            if (generateTransform != null)
            {
                Position = generateTransform.position;
                EulerAngles = generateTransform.eulerAngles;
                Rotation = generateTransform.rotation;
                Name = generateTransform.name;
            }
            else
            {
                Position = Vector3.zero;
                EulerAngles = Vector3.zero;
                Rotation = Quaternion.identity;
                Name = "";
            }
        }
    }
}