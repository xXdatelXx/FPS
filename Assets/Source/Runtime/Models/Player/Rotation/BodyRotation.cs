using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace FPS.Model.Rotation
{
    public sealed class BodyRotation : IBodyRotation
    {
        private readonly CharacterController _body;

        public BodyRotation(CharacterController body) =>
            _body = body.ThrowExceptionIfArgumentNull(nameof(body));

        public void Rotate(float euler) => 
            _body.Rotate(new Vector3(0, euler));
    }
}