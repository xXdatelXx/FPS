using FPS.Tools;

namespace FPS.Model
{
    public sealed class RayBullet : IBullet
    {
        private readonly float _damage;
        private readonly IDamagePolicy _damagePolicy;
        private readonly IRay _ray;
        private readonly IBulletView _view;
        
        public RayBullet(float damage, IDamagePolicy damagePolicy, IRay ray) : 
            this(damage, damagePolicy, ray, new NullBulletView())
        { }

        public RayBullet(float damage, IDamagePolicy damagePolicy, IRay ray, IBulletView view)
        {
            _damage = damage.ThrowExceptionIfValueSubZero(nameof(damage));
            _damagePolicy = damagePolicy.ThrowExceptionIfArgumentNull(nameof(damagePolicy));
            _ray = ray.ThrowExceptionIfArgumentNull(nameof(ray));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public void Fire()
        {
            if (_ray.Cast(out var hit))
            {
                if (CanDamage(out var health, hit))
                {
                    var damage = _damagePolicy.Affect(_damage, hit.Distance);
                    health.TakeDamage(damage);

                    _view.Damage();

                    if (health.Died)
                        _view.Kill();
                }

                _view.Hit(hit.Point);
            }
            else _view.Miss();
        }

        private bool CanDamage(out IHealth health, IRayHit hit) =>
            hit.Is(out health) && !health.Died;
    }
}