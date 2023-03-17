using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletRay : IBulletRay
    {
        private readonly IGameObjectWithMovement _movement;
        private readonly Vector3 _standardMotion;
        private readonly IPositionWithVectorTransform _standardPosition;
        private readonly IGameObject _gameObject;

        public BulletRay(IGameObjectWithMovement movement, Vector3 standardMotion, IPositionWithVectorTransform standardPosition, IGameObject gameObject)
        {
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            _standardPosition = standardPosition.ThrowExceptionIfArgumentNull(nameof(standardPosition));
            _gameObject = gameObject.ThrowExceptionIfArgumentNull(nameof(gameObject));
            _standardMotion = standardMotion;
        }

        public void Cast() => 
            Cast(_standardPosition.World + _standardPosition.TransformVector(_standardMotion));

        public void Cast(Vector3 target)
        {
            _movement.Position = _standardPosition.World;
            
            if (!_gameObject.Active)
                _gameObject.Enable();

            _movement.MoveTo(target);
        }

        public void Hide()
        {
            if (_gameObject.Active)
                _gameObject.Disable();
        }
    }
}