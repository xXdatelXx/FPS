using FPS.Tools;
using UnityEngine;

namespace FPS.Views
{
    public sealed class GameObjectWithMovement : IGameObjectWithMovement
    {
        private readonly Transform _transform;

        public GameObjectWithMovement(Transform transform) => 
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));

        public void MoveTo(Vector3 point) => _transform.position = point;
    }
}