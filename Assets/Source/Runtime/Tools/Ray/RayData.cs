using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace Source.Runtime.Tools.Ray
{
    public struct RayData<TTarget> : IRayData<TTarget>
    {
        public RayData(Vector3 point, float distance, TTarget target)
        {
            Point = point;
            Distance = distance.ThrowExceptionIfValueSubZero(nameof(distance));
            Target = target.ThrowExceptionIfArgumentNull(nameof(target));
        }

        public Vector3 Point { get; }
        public float Distance { get; }
        public TTarget Target { get; }
    }
}