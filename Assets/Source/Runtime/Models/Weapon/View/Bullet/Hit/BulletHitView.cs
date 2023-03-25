using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletHitView : IBulletHitView
    {
        private readonly IBulletParticle _particle;
        private readonly IGameObjectWithMovement _movement;

        public BulletHitView(IBulletParticle particle, IGameObjectWithMovement movement)
        {
            _particle = particle.ThrowExceptionIfArgumentNull(nameof(particle));
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
        }

        public void Visualize(Vector3 target)
        {
            _movement.MoveTo(target);
            _particle.Play();
        }

        public void Hide() => _particle.Stop();
    }
}