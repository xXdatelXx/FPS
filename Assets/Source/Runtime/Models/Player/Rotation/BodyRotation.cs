using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BodyRotation : IBodyRotation
    {
        private readonly IGameObjectWithRotation _body;

        public BodyRotation(IGameObjectWithRotation body) =>
            _body = body.ThrowExceptionIfArgumentNull(nameof(body));

        public void Rotate(float euler) =>
            _body.Rotate(new Vector3(0, euler));
    }
}