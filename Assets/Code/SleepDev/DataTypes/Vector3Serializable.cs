using UnityEngine;

namespace SleepDev
{
    [System.Serializable]
    public struct Vector3Serializable
    {
        public float x;
        public float y;
        public float z;

        public Vector3Serializable(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // public Vector3Serializable()
        // {
        //     x = 0;
        //     y = 0;
        //     z = 0;
        // }

        public Vector3Serializable(Vector3Serializable other)
        {
            x = other.x;
            y = other.y;
            z = other.z;
        }
        
        public static Vector3Serializable one => new Vector3Serializable(1,1,1);
        public static Vector3Serializable zero => new Vector3Serializable(0,0,0);

        public UnityEngine.Vector3 GetVec() => new Vector3(x, y, z);

        public Vector3Serializable FromVec(UnityEngine.Vector3 vec) => new Vector3Serializable(vec.x, vec.y, vec.z);

        public static bool operator ==(Vector3Serializable l, Vector3Serializable r)
        {
            return l.x == r.x && l.y == r.y && l.z == r.z;
        }

        public static bool operator !=(Vector3Serializable l, Vector3Serializable r)
        {
            return !(l == r);
        }

        public static implicit operator Vector3Serializable(Vector3 vec)
        {
            return new Vector3Serializable(vec.x, vec.y, vec.z);
        }

        public static implicit operator Vector3(Vector3Serializable vec)
        {
            return new Vector3(vec.x, vec.y, vec.z);
        }
    }
}