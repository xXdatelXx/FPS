using System;
using UnityEngine;

namespace FPS.Toolkit
{
    public sealed class Position : IPosition
    {
        private readonly Transform _transform;

        public Position(Transform transform) =>
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));

        public Vector3 Value
        {
            get => _transform.position;
            private set => _transform.position = value;
        }
        
        public Vector3 Forward => _transform.forward;

        public void TeleportTo(Vector3 position)
        {
            if (Value == position)
                throw new ArgumentOutOfRangeException($"Transform already in {position}");

            Value = position;
        }
    }
}