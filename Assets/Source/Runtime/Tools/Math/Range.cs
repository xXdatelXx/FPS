using System;
using UnityEngine;

namespace Source.Runtime.Tools.Math
{
    [Serializable]
    public struct Range
    {
        [field: SerializeField] public float Min { get; private set; }
        [field: SerializeField] public float Max { get; private set; }

        public Range(float min, float max)
        {
            if (max < min)
                throw new ArgumentException("max < min");

            (Max, Min) = (max, min);
        }
    }
}