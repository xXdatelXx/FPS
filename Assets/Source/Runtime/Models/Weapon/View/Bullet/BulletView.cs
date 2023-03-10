using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletView : IBulletView
    {
        private readonly IBulletParticle _particle;
        private readonly IBulletHitsView _hits;
        private readonly IBulletRays _rays;
        private readonly ICrosshair _crosshair;

        public BulletView(IBulletParticle particle, IBulletHitsView hits, IBulletRays rays, ICrosshair crosshair)
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

        public void Hit(Vector3 target, Vector3 normal)
        {
            _particle.Play();
            _hits.Visualize(target, normal);
            _rays.Cast(target);
            _crosshair.Hit();
        }

        public void Kill() => _crosshair.Kill();
    }
}