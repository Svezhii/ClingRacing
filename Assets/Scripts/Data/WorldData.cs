using System;

namespace Data
{
    [Serializable]
    public class WorldData
    {
        public Vector3Data Position;
        public RotationData Rotation;
    }

    public class RotationData
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public RotationData(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
}