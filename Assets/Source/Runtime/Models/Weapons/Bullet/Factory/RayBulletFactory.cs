using Source.Runtime.Models.Health;
using Source.Runtime.Tools.Extensions;
using Source.Runtime.Tools.Ray;

namespace Source.Runtime.Models.Weapons.Bullet.Factory
{
    public sealed class RayBulletFactory : IBulletFactory
    {
        private readonly float _damage;
        private readonly IRaySpawnPoint _spawnPoint;
        private readonly IDamageCoefficient _damageCoefficient;

        public RayBulletFactory(IRaySpawnPoint spawnPoint, float damage, IDamageCoefficient damageCoefficient)
        {
            _spawnPoint = spawnPoint.ThrowExceptionIfArgumentNull(nameof(spawnPoint));
            _damage = damage.ThrowExceptionIfValueSubZero(nameof(damage));
            _damageCoefficient = damageCoefficient.ThrowExceptionIfArgumentNull(nameof(damageCoefficient));
        }

        public IBullet Create()
        {
            var ray = new UnityRay<IHealth>(_spawnPoint);
            var damagePolicy = new DamagePolicy(_damageCoefficient);
            
            return new RayBullet(_damage, damagePolicy, ray);
        }
    }
}