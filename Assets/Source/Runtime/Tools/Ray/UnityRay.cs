using UnityEngine;

namespace FPS.Tools
{
    public sealed class UnityRay : IRay
    {
        private readonly Ray _ray;

        public UnityRay(IRaySpawnPoint origin)
        {
            origin.ThrowExceptionIfArgumentNull(nameof(origin));
            _ray = new Ray(origin.Position, origin.Forward);
        }

        public bool Cast(out IRayHit hit)
        {
            if (Physics.Raycast(_ray, out var raycastHit))
            {
                hit = new RayHit(raycastHit.point, raycastHit.distance, raycastHit.collider);
                return true;
            }

            hit = default;
            return false;
        }
    }
}