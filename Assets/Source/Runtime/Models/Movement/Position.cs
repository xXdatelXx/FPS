using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public readonly struct Position : IPosition
    {
        private readonly Transform _transform;

        public Position(Transform transform) => 
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));

        public Vector3 World => _transform.position;
        public Vector3 Local => _transform.localPosition;
    }
}