using UnityEngine;

namespace FPS.Tools
{
    public readonly struct RayHit : IRayHit
    {
        public RayHit(Vector3 point, Vector3 normal, float distance, Collider target)
        {
            Point = point;
            Normal = normal;
            Distance = distance.ThrowExceptionIfValueSubZero(nameof(distance));
            _target = target;
        }

        public Vector3 Point { get; }
        public Vector3 Normal { get; }
        public float Distance { get; }
        private Collider _target { get; }
        public bool Is<T>(out T t) => _target.TryGetComponent(out t);
    }
}