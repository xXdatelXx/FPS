using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletHitView : IBulletHitView
    {
        private readonly IMovement _movement;
        private readonly IBulletParticle _particle;

        public BulletHitView(IMovement movement, IBulletParticle particle)
        {
            _particle = particle.ThrowExceptionIfArgumentNull(nameof(particle));
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
        }

        public void Visualize(Vector3 target)
        {
            _movement.Move(target - _movement.Position.Value);
            _particle.Play();
        }

        public void Hide() => _particle.Stop();
    }
}