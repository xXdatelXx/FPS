using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletTrace : IBulletTrace
    {
        private readonly IMovementWithTeleport _movement;
        private readonly IGameObject _gameObject;
        private readonly IPositionWithVectorTransform _throwPosition;
        private readonly Vector3 _standardMotion;

        public BulletTrace(IMovementWithTeleport movement, IGameObject gameObject, IPositionWithVectorTransform throwPosition, Vector3 standardMotion)
        {
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            _gameObject = gameObject.ThrowExceptionIfArgumentNull(nameof(gameObject));
            _throwPosition = throwPosition.ThrowExceptionIfArgumentNull(nameof(throwPosition));
            _standardMotion = standardMotion;
        }

        public void Cast() =>
            Cast(_throwPosition.Value + _throwPosition.TransformVector(_standardMotion));

        public void Cast(Vector3 target)
        {
            if (!_movement.Position.IsSame(_throwPosition))
                _movement.TeleportTo(_throwPosition.Value);

            if (!_gameObject.Active)
                _gameObject.Enable();

            _movement.Move(target - _movement.Position.Value);
        }

        public void Hide()
        {
            if (_gameObject.Active)
                _gameObject.Disable();
        }
    }
}