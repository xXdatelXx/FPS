using FPS.Tools;
using UnityEngine;

namespace FPS.Views
{
    public sealed class MovementGameObject : IMovementGameObject
    {
        private readonly IGameObject _gameObject;
        private readonly IGameObjectWithMovement _movement;

        public MovementGameObject(IGameObject gameObject, IGameObjectWithMovement movement)
        {
            _gameObject = gameObject.ThrowExceptionIfArgumentNull(nameof(gameObject));
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
        }

        public bool Active => _gameObject.Active;

        public void MoveTo(Vector3 point) => _movement.MoveTo(point);

        public void Destroy() => _gameObject.Destroy();

        public void Enable() => _gameObject.Enable();

        public void Disable() => _gameObject.Disable();
    }
}