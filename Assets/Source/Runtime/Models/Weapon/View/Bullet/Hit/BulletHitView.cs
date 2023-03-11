using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletHitView : IBulletHitView
    {
        private readonly IBulletParticle _particle;
        private readonly ISpite _sprite;
        private readonly IGameObjectWithMovement _movement;
        private readonly IGameObjectWithRotation _rotation;

        public BulletHitView(IBulletParticle particle, ISpite sprite, IGameObjectWithMovement movement, IGameObjectWithRotation rotation)
        {
            _particle = particle.ThrowExceptionIfArgumentNull(nameof(particle));
            _sprite = sprite.ThrowExceptionIfArgumentNull(nameof(sprite));
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            _rotation = rotation.ThrowExceptionIfArgumentNull(nameof(rotation));
        }

        public void Visualize(Vector3 target, Vector3 normal)
        {
            _movement.MoveTo(target);
            _rotation.RotateTo(normal);
            
            _particle.Play();
            _sprite.Render();
        }

        public void Hide()
        {
            _particle.Stop();
            _sprite.Hide();
        }
    }
}