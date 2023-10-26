using UnityEngine;

namespace FPS.Toolkit
{
    public static class VectorExtension
    {
        public static Vector3 Multiply(this Vector3 a, Vector3 b) =>
            new(a.x * b.x, a.y * b.y, a.z * b.z);

        public static Vector3 ThrowExceptionIfValuesSubZero(this Vector3 vector, string name)
        {
            vector.x.ThrowExceptionIfValueSubZero(name);
            vector.y.ThrowExceptionIfValueSubZero(name);
            vector.z.ThrowExceptionIfValueSubZero(name);

            return vector;
        }

        public static Vector3Int ThrowExceptionIfValuesSubZero(this Vector3Int vector, string name)
        {
            ThrowExceptionIfValuesSubZero((Vector3)vector, name);
            return vector;
        }
    }
}