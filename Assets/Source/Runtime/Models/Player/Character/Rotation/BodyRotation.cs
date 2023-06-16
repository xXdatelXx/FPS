using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BodyRotation : IBodyRotation
    {
        private readonly IRotation _body;

        public BodyRotation(IRotation body) =>
            _body = body.ThrowExceptionIfArgumentNull(nameof(body));

        public void Rotate(float euler) =>
            _body.Rotate(new Vector3(0, euler));
    }
}