using FPS.Tools;
using UnityEngine;

namespace FPS.Tools
{
    public sealed class GameObjectWithRotation : IGameObjectWithRotation
    {
        private readonly Transform _transform;

        public GameObjectWithRotation(Transform transform) =>
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));

        public Vector3 Rotation => _transform.localEulerAngles;

        public void Rotate(Vector3 euler) => _transform.Rotate(euler);
    }
}