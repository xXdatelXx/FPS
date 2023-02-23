using Source.Runtime.Models.Weapons.Bullet.Factory;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace Source.Runtime.Tools.Ray
{
    public sealed class UnityRay<TTarget> : IRay<TTarget>
    {
        private readonly IRaySpawnPoint _origin;

        public UnityRay(IRaySpawnPoint origin) => 
            _origin = origin.ThrowExceptionIfArgumentNull(nameof(origin));

        public bool Cast(out IRayData<TTarget> data)
        {
            var ray = new UnityEngine.Ray(_origin.Position, _origin.Forward);
            
            if (Physics.Raycast(ray, out var hit))
                if (hit.collider.Is(out data))
                    return true;

            data = default;
            return false;
        }
    }
}