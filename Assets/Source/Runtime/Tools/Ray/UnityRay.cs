using UnityEngine;

namespace FPS.Tools
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

        public void Cast(out RayHit<TTarget> hit)
        {
             hit = 
                 Physics.Raycast(_ray, out var raycastHit) 
                     ? new RayHit<TTarget>(raycastHit.collider.GetComponent<TTarget>(), _origin.Value, raycastHit.point) 
                     : default;
        }
    }
}