using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace Source.Runtime.Tools.Ray
{
    public readonly struct RayHit : IRayHit
    {
        public RayHit(Vector3 point, float distance, Collider target)
        {
            Point = point;
            Distance = distance.ThrowExceptionIfValueSubZero(nameof(distance));
            _target = target;
        }

        public Vector3 Point { get; }
        public float Distance { get; }
        private Collider _target { get; }
        public bool Is<T>(out T t) => _target.TryGetComponent(out t);
    }
}