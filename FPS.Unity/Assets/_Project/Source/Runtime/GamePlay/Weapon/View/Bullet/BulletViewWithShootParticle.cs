using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletViewWithShootParticle : IBulletView
    {
        private readonly IBulletView _bullet;
        private readonly IBulletParticle _shootParticle;

        public BulletViewWithShootParticle(IBulletView bullet, IBulletParticle shootParticle)
        {
            _bullet = bullet.ThrowExceptionIfArgumentNull(nameof(bullet));
            _shootParticle = shootParticle.ThrowExceptionIfArgumentNull(nameof(shootParticle));
        }

        public BulletViewWithShootParticle(IBulletParticle shootParticle) : this(new NullBulletView(), shootParticle)
        { }

        public void Miss()
        {
            _bullet.Miss();
            _shootParticle.Play();
        }

        public void Hit(Vector3 target)
        {
            _bullet.Hit(target);
            _shootParticle.Play();
        }

        public void Kill() => _bullet.Kill();

        public void Damage() => _bullet.Damage();
    }
}