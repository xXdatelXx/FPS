using UnityEngine;

namespace FPS.Tools
{
    public readonly struct RayHit : IRayHit
    {
        public RayHit(Vector3 point, float distance, Collider target)
        {
            Point = point;
            Distance = distance.ThrowExceptionIfValueSubZero(nameof(distance));
            _target = target.ThrowExceptionIfArgumentNull(nameof(target));
        }

        public Vector3 Point { get; }
        public float Distance { get; }

        private readonly Collider _target;

        public bool Is<T>(out T t) =>
            _target.TryGetComponent(out t);
    }
}