using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class Movement : IMovement
    {
        private readonly Transform _transform;

        public Movement(Transform transform) =>
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));

        public Vector3 Position => _transform.position;

        public void Move(Vector3 motion) => _transform.position += motion;
        public void MoveByRotation(Vector3 motion) => Move(_transform.TransformVector(motion));
    }
}