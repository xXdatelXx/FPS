using DG.Tweening;
using UnityEngine;

namespace FPS.Tools
{
    public sealed class GameObjectWithDoTweenMovement : IGameObjectWithMovement
    {
        private readonly float _speed;
        private readonly Transform _transform;

        public GameObjectWithDoTweenMovement(Transform transform, float speed)
        {
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));
            _speed = speed.ThrowExceptionIfValueSubZero(nameof(speed));
        }

        public Vector3 Position
        {
            get => _transform.position;
            set => _transform.position = value;
        }

        public void MoveTo(Vector3 point)
        {
            var duration = Vector3.Distance(Position, point) / _speed;
            _transform.DOMove(point, duration);
        }
    }
}