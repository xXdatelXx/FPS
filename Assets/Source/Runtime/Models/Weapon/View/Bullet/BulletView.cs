using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletView : IBulletView
    {
        private readonly IBulletParticle _particle;
        private readonly IBulletHitView _hit;
        private readonly IBulletRay _ray;

        public BulletView(IBulletParticle particle, IBulletHitView hit, IBulletRay ray)
        {
            _particle = particle.ThrowExceptionIfArgumentNull(nameof(particle));
            _hit = hit.ThrowExceptionIfArgumentNull(nameof(hit));
            _ray = ray.ThrowExceptionIfArgumentNull(nameof(ray));
        }

        public void Visualize(Vector3 target)
        {
            _particle.Play();
            _hit.Update(target);
            _ray.Cast(target);
        }
    }
}