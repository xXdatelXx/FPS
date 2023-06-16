using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletView : IBulletView
    {
        private readonly IBulletParticle _particle;
        private readonly IBulletHitView _hits;
        private readonly IBulletRay _rays;
        private readonly ICrosshair _crosshair;

        public BulletView(IBulletParticle particle, IBulletHitView hits, IBulletRay rays, ICrosshair crosshair)
        {
            _particle = particle.ThrowExceptionIfArgumentNull(nameof(particle));
            _hits = hits.ThrowExceptionIfArgumentNull(nameof(hits));
            _rays = rays.ThrowExceptionIfArgumentNull(nameof(rays));
            _crosshair = crosshair.ThrowExceptionIfArgumentNull(nameof(crosshair));
        }

        public void Miss()
        {
            _particle.Play();
            _rays.Cast();
        }

        public void Hit(Vector3 target)
        {
            _particle.Play();
            _hits.Visualize(target);
            _rays.Cast(target);
        }

        public void Damage() => _crosshair.Hit();
        public void Kill() => _crosshair.Kill();
    }
}