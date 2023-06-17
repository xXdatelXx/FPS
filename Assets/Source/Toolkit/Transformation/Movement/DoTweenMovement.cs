using DG.Tweening;
using UnityEngine;
using UnityTransform = UnityEngine.Transform;

namespace FPS.Toolkit
{
    public sealed class DoTweenMovement : IMovement
    {
        private readonly float _speed;
        private readonly UnityTransform _transform;

        public DoTweenMovement(UnityTransform transform, float speed)
        {
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));
            _speed = speed.ThrowExceptionIfValueSubZero(nameof(speed));
        }

        public Vector3 Position => _transform.position;

        public void Move(Vector3 motion)
        {
            var nextPosition = Position + motion;
            var duration = Vector3.Distance(Position, nextPosition) / _speed;

            _transform.DOMove(nextPosition, duration);
        }
    }
}