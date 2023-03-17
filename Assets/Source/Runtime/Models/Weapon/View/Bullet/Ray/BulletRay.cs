using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletRay : IBulletRay
    {
        private readonly IGameObjectWithMovement _movement;
        private readonly Vector3 _standardMotion;
        private readonly IPosition _standardPosition;
        private readonly IGameObject _gameObject;

        public BulletRay(IGameObjectWithMovement movement, Vector3 standardMotion, IPosition standardPosition, IGameObject gameObject)
        {
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            _standardPosition = standardPosition.ThrowExceptionIfArgumentNull(nameof(standardPosition));
            _gameObject = gameObject.ThrowExceptionIfArgumentNull(nameof(gameObject));
            _standardMotion = standardMotion;
        }

        public void Cast() =>
            Cast(_movement.Position + _standardMotion);

        public void Cast(Vector3 target)
        {
            if (!_gameObject.Active)
                _gameObject.Enable();
            
            _movement.MoveTo(target);
        }

        public void Hide()
        {
            if (_gameObject.Active)
                _gameObject.Disable();
            
            _movement.MoveTo(_standardPosition.World);
        }
    }
}