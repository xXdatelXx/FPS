using FPS.Tools;

namespace FPS.Model
{
    public sealed class RayBulletFactory : IBulletFactory
    {
        private readonly float _damage;
        private readonly IDamageCoefficient _damageCoefficient;
        private readonly IRaySpawnPoint _spawnPoint;
        private readonly IBulletView _view;

        public RayBulletFactory(IRaySpawnPoint spawnPoint, float damage, IDamageCoefficient damageCoefficient) 
            : this(spawnPoint, damage,damageCoefficient, new NullBulletView())
        { }
        
        public RayBulletFactory(IRaySpawnPoint spawnPoint, float damage, IDamageCoefficient damageCoefficient, IBulletView view)
        {
            _spawnPoint = spawnPoint.ThrowExceptionIfArgumentNull(nameof(spawnPoint));
            _damage = damage.ThrowExceptionIfValueSubZero(nameof(damage));
            _damageCoefficient = damageCoefficient.ThrowExceptionIfArgumentNull(nameof(damageCoefficient));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public IBullet Create()
        {
            var ray = new UnityRay(_spawnPoint);
            var damagePolicy = new DamagePolicy(_damageCoefficient);

            return new RayBullet(_damage, damagePolicy, ray, _view);
        }
    }
}