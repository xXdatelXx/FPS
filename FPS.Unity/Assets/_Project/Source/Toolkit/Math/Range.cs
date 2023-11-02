using System;
using UnityEngine;

namespace FPS.Toolkit
{
    [Serializable]
    public struct Range
    {
        public Range(float min, float max)
        {
            if (max < min)
                throw new ArgumentException("max < min");

            (Max, Min) = (max, min);
        }

        [field: SerializeField] public float Min { get; private set; }
        [field: SerializeField] public float Max { get; private set; }
        public float Delta => Max - Min;
    }
}