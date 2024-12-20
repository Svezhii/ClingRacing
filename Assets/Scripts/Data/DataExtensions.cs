using System.Data;
using UnityEngine;

namespace Data
{
    public static class DataExtensions
    {
        public static Vector3Data AsVectorData(this Vector3 vector) =>
            new Vector3Data(vector.x, vector.y, vector.z);
        
        public static Vector3 AsUnityVector(this Vector3Data vector3Data) =>
        new Vector3(vector3Data.X, vector3Data.Y, vector3Data.Z);
        
        public static RotationData AsQuaternionData(this Quaternion quaternion) =>
            new RotationData(quaternion.x, quaternion.y, quaternion.z, quaternion.w);

        public static Quaternion AsUnityQuaternion(this RotationData rotationData) =>
            new Quaternion(rotationData.X, rotationData.Y, rotationData.Z, rotationData.W);
    }
}