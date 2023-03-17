using UnityEngine;

namespace FPS.Tools
{
    public sealed class GameObjectWithMovement : IGameObjectWithMovement
    {
        private readonly Transform _transform;

        public GameObjectWithMovement(Transform transform) => 
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));

        public Vector3 Position
        {
            get => _transform.position;
            set => _transform.position = value;
        }
        
        public void MoveTo(Vector3 point) => _transform.position = point;
    }
}