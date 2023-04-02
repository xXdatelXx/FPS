using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class Rotation : IRotation
    {
        private readonly Transform _transform;

        public Rotation(Transform transform) =>
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));

        public Vector3 Value => _transform.localEulerAngles;

        public void Rotate(Vector3 euler) => _transform.Rotate(euler);
    }
}