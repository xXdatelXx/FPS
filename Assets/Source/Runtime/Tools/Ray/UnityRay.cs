using Source.Runtime.Models.Weapons.Bullet.Factory;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace Source.Runtime.Tools.Ray
{
    public sealed class UnityRay<TTarget> : IRay<TTarget>
    {
        private readonly UnityEngine.Ray _ray;

        public UnityRay(IRaySpawnPoint origin)
        {
            origin.ThrowExceptionIfArgumentNull(nameof(origin));
            _ray = new UnityEngine.Ray(origin.Position, origin.Forward);
        }

        public bool Cast(out IRayData<TTarget> data)
        {
            if (Physics.Raycast(_ray, out var hit))
            {
                if (hit.Is(out data))
                    return true;
            }

            data = default;
            return false;
        }
    }
}