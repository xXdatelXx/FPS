using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletViewWithParticles : IBulletView
    {
        private readonly IBulletView _bullet;
        private readonly IBulletParticle _particle;
        private readonly IBulletHitView _hits;

        public BulletViewWithParticles(IBulletView bullet, IBulletParticle particle, IBulletHitView hits)
        {
            _bullet = bullet.ThrowExceptionIfArgumentNull(nameof(bullet));
            _particle = particle.ThrowExceptionIfArgumentNull(nameof(particle));
            _hits = hits.ThrowExceptionIfArgumentNull(nameof(hits));
        }
        
        public BulletViewWithParticles(IBulletParticle particle, IBulletHitView hits) 
            : this(new NullBulletView(), particle, hits)
        { }

        public void Miss()
        {
            _bullet.Miss();
            _particle.Play();
        }

        public void Hit(Vector3 target)
        {
            _bullet.Hit(target);
            _particle.Play();
            _hits.Visualize(target);
        }

        public void Kill() => _bullet.Kill();

        public void Damage() => _bullet.Damage();
    }
}