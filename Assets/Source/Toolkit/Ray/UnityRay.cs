using UnityEngine;

namespace FPS.Toolkit
{
    public sealed class UnityRay<TTarget> : IRay<TTarget>
    {
        private readonly Ray _ray;
        private readonly IRaySpawnPoint _origin;

        public UnityRay(IRaySpawnPoint origin)
        {
            origin.ThrowExceptionIfArgumentNull(nameof(origin));
            _ray = new Ray(origin.Value, origin.Forward);
            _origin = origin;
        }

        public bool Cast(out RayHit<TTarget> hit)
        {
            var occured = Physics.Raycast(_ray, out var raycastHit);

            hit = occured
                ? new(raycastHit.GetComponent<TTarget>(), _origin.Value, raycastHit.point)
                : default;

            return occured;
        }
    }
}