using Source.Runtime.Models.Weapons.Bullet.Factory;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace Source.Runtime.Tools.Ray
{
    public sealed class UnityRay : IRay
    {
        private readonly UnityEngine.Ray _ray;

        public UnityRay(IRaySpawnPoint origin)
        {
            origin.ThrowExceptionIfArgumentNull(nameof(origin));
            _ray = new UnityEngine.Ray(origin.Position, origin.Forward);
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