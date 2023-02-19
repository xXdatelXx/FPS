using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.Models.Weapons.Bullet.Factory
{
    public sealed class RayBulletFactory : IBulletFactory
    {
        private readonly float _damage;
        private readonly IBulletSpawnPoint _spawnPoint;

        public RayBulletFactory(IBulletSpawnPoint spawnPoint, float damage)
        {
            _spawnPoint = spawnPoint.ThrowExceptionIfArgumentNull(nameof(spawnPoint));
            _damage = damage.ThrowExceptionIfValueSubZero(nameof(damage));
        }

        public IBullet Create() => new RayBullet(_damage, _spawnPoint);
    }
}