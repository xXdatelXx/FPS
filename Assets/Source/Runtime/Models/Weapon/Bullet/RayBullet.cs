using FPS.Tools;

namespace FPS.Model
{
    public sealed class RayBullet : IBullet
    {
        private readonly float _damage;
        private readonly IDamagePolicy _damagePolicy;
        private readonly IRay<IHealth> _ray;
        private readonly IBulletView _view;
        
        public RayBullet(float damage, IDamagePolicy damagePolicy, IRay<IHealth> ray) : 
            this(damage, damagePolicy, ray, new NullBulletView())
        { }

        public RayBullet(float damage, IDamagePolicy damagePolicy, IRay<IHealth> ray, IBulletView view)
        {
            _damage = damage.ThrowExceptionIfValueSubZero(nameof(damage));
            _damagePolicy = damagePolicy.ThrowExceptionIfArgumentNull(nameof(damagePolicy));
            _ray = ray.ThrowExceptionIfArgumentNull(nameof(ray));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public void Fire()
        {
            _ray.Cast(out var hit);
            
            if (hit.Occurred)
            {
                var target = hit.Target;
                if (target.Alive())
                {
                    var damage = _damagePolicy.Affect(_damage, hit.Distance());
                    target.TakeDamage(damage);

                    _view.Damage();

                    if (target.Died)
                        _view.Kill();
                }

                _view.Hit(hit.Points.End);
            }
            else _view.Miss();
        }
    }
}