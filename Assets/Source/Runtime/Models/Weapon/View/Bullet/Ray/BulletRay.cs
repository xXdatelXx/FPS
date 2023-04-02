using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletRay : IBulletRay
    {
        private readonly IMovementWithTeleport _movement;
        private readonly IGameObject _gameObject;
        private readonly IPositionWithVectorTransform _standardPosition;
        private readonly Vector3 _standardMotion;

        public BulletRay(IMovementWithTeleport movement, IGameObject gameObject, IPositionWithVectorTransform standardPosition, Vector3 standardMotion)
        {
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            _gameObject = gameObject.ThrowExceptionIfArgumentNull(nameof(gameObject));
            _standardPosition = standardPosition.ThrowExceptionIfArgumentNull(nameof(standardPosition));
            _standardMotion = standardMotion;
        }

        public void Cast() =>
            Cast(_standardPosition.Value + _standardPosition.TransformVector(_standardMotion));

        public void Cast(Vector3 target)
        {
            _movement.TeleportTo(_standardPosition.Value);

            if (!_gameObject.Active)
                _gameObject.Enable();

            _movement.Move(target - _movement.Position);
        }

        public void Hide()
        {
            if (_gameObject.Active)
                _gameObject.Disable();
        }
    }
}