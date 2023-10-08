using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletView : IBulletView
    {
        private readonly IBulletParticle _particle;
        private readonly IBulletHitView _hits;
        private readonly IBulletTrace _traces;
        private readonly ICrosshair _crosshair;

        public BulletView(IBulletParticle particle, IBulletHitView hits, IBulletTrace traces, ICrosshair crosshair)
        {
            _particle = particle.ThrowExceptionIfArgumentNull(nameof(particle));
            _hits = hits.ThrowExceptionIfArgumentNull(nameof(hits));
            _traces = traces.ThrowExceptionIfArgumentNull(nameof(traces));
            _crosshair = crosshair.ThrowExceptionIfArgumentNull(nameof(crosshair));
        }

        public void Miss()
        {
            _particle.Play();
            _traces.Cast();
        }

        public void Hit(Vector3 target)
        {
            _particle.Play();
            _hits.Visualize(target);
            _traces.Cast(target);
        }

        public void Damage() => _crosshair.Hit();
        public void Kill() => _crosshair.Kill();
    }
}