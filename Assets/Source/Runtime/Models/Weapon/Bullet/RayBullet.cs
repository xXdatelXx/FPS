using Source.Runtime.Model.Health;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace FPS.Model.Weapons.Bullet
{
    public sealed class RayBullet : IBullet
    {
        private readonly float _damage;
        private readonly IBulletSpawnPoint _origin;

        public RayBullet(float damage, IBulletSpawnPoint origin)
        {
            _damage = damage.ThrowExceptionIfValueSubZero(nameof(damage));
            _origin = origin.ThrowExceptionIfArgumentNull(nameof(origin));
        }

        public void Fire(Vector3 direction)
        {
            var ray = new Ray(_origin.Position, direction);
            
            if (ray.Cast(out IHealth health)) 
                health.TakeDamage(_damage);
        }
    }
}