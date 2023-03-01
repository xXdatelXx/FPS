using FPS.Tools;
using JetBrains.Annotations;

namespace FPS.Model
{
    public sealed class RayBullet : IBullet
    {
        private readonly float _damage;
        private readonly IDamagePolicy _damagePolicy;
        private readonly IRay _ray;
        [CanBeNull] private readonly IBulletView _view;

        public RayBullet(float damage, IDamagePolicy damagePolicy, IRay ray, IBulletView view = null)
        {
            _damage = damage.ThrowExceptionIfValueSubZero(nameof(damage));
            _damagePolicy = damagePolicy.ThrowExceptionIfArgumentNull(nameof(damagePolicy));
            _ray = ray.ThrowExceptionIfArgumentNull(nameof(ray));
            _view = view;
        }

        public void Fire()
        {
            if (_ray.Cast(out var hit))
            {
                if (CanDamage(out var health, hit))
                {
                    var damage = _damagePolicy.Affect(_damage, hit.Distance);
                    health.TakeDamage(damage);
                }

                _view?.Visualize(hit.Point);
            }
        }

        private bool CanDamage(out IHealth health, IRayHit hit) =>
            hit.Is(out health) && !health.Died;
    }
}