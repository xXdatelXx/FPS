using System;
using UnityEngine;

namespace FPS.Tools
{
    public sealed class Position : IPosition, IPositionWithVectorTransform
    {
        private readonly Transform _transform;

        public Position(Transform transform) =>
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));

        public Vector3 Value
        {
            get => _transform.position;
            private set => _transform.position = value;
        }

        public void TeleportTo(Vector3 position)
        {
            if (Value == position)
                throw new ArgumentOutOfRangeException($"Transform already in {position}");

            Value = position;
        }

        public Vector3 TransformVector(Vector3 vector) =>
            _transform.TransformVector(vector);

        public Vector3 TransformPoint(Vector3 vector) =>
            _transform.TransformPoint(vector);

        public Vector3 TransformDirection(Vector3 vector) =>
            _transform.TransformDirection(vector);
    }
}