using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public readonly struct Position : IPositionWithVectorTransform
    {
        private readonly Transform _transform;

        public Position(Transform transform) =>
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));

        public Vector3 Value => _transform.position;

        public Vector3 TransformVector(Vector3 vector) =>
            _transform.TransformVector(vector);

        public Vector3 TransformPoint(Vector3 vector) =>
            _transform.TransformPoint(vector);

        public Vector3 TransformDirection(Vector3 vector) =>
            _transform.TransformDirection(vector);
    }
}