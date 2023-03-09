using FPS.Tools;
using FPS.Views;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletHit : IBulletHit
    {
        private readonly IBulletParticle _particle;
        private readonly IBulletHitSprites _sprites;
        private readonly IMovementGameObject _gameObject;

        public BulletHit(IBulletParticle particle, IBulletHitSprites sprites, IMovementGameObject gameObject)
        {
            _particle = particle.ThrowExceptionIfArgumentNull(nameof(particle));
            _sprites = sprites.ThrowExceptionIfArgumentNull(nameof(sprites));
            _gameObject = gameObject.ThrowExceptionIfArgumentNull(nameof(gameObject));
        }

        public void Activate() =>
            _gameObject.Enable();

        public void Deactivate() =>
            _gameObject.Disable();

        public void Update(Vector3 hit)
        {
            _particle.Play();
            _sprites.Update();
            _gameObject.MoveTo(hit);
        }
    }
}