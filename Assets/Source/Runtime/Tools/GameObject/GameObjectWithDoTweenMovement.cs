using DG.Tweening;
using FPS.Tools;
using UnityEngine;

namespace FPS.Tools
{
    public sealed class GameObjectWithDoTweenMovement : IGameObjectWithMovement
    {
        private readonly Transform _transform;
        private readonly float _speed;

        public GameObjectWithDoTweenMovement(Transform transform, float speed)
        {
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));
            _speed = speed.ThrowExceptionIfValueSubZero(nameof(speed));
        }

        public Vector3 Position => _transform.position;
        
        public void MoveTo(Vector3 point)
        {
            var duration = Vector3.Distance(Position, point) / _speed;
            _transform.DOMove(point, duration);
        }
    }
}