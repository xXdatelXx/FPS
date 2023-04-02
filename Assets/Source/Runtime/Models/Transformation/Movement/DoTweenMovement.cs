using DG.Tweening;
using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class DoTweenMovement : IMovement
    {
        private readonly float _speed;
        private readonly Transform _transform;

        public DoTweenMovement(Transform transform, float speed)
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

        public void MoveByRotation(Vector3 motion) => Move(_transform.TransformVector(motion));
    }
}