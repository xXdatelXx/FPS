using Source.Runtime.Models.HealthSystem;
using Source.Runtime.Tools.Extensions;
using Source.Runtime.Tools.Ray;

namespace Source.Runtime.Models.Weapons.Bullet
{
    public sealed class RayBullet : IBullet
    {
        private readonly float _damage;
        private readonly IDamagePolicy _damagePolicy;
        private readonly IRay<IHealth> _ray;

        public RayBullet(float damage, IDamagePolicy damagePolicy, IRay<IHealth> ray)
        {
            _damage = damage.ThrowExceptionIfValueSubZero(nameof(damage));
            _damagePolicy = damagePolicy.ThrowExceptionIfArgumentNull(nameof(damagePolicy));
            _ray = ray.ThrowExceptionIfArgumentNull(nameof(ray));
        }

        public void Fire()
        {
            if (_ray.Cast(out var hit))
            {
                if (hit.Target.Died)
                    return;

                var damage = _damagePolicy.Affect(_damage, hit.Distance);
                hit.Target.TakeDamage(damage);
            }
        }
    }
}