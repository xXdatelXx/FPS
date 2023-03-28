using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletHitView : IBulletHitView
    {
        private readonly IGameObjectWithMovement _movement;
        private readonly IBulletParticle _particle;

        public BulletHitView(IGameObjectWithMovement movement, IBulletParticle particle)
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