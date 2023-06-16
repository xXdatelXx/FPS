using FPS.Toolkit;
using UnityEngine;

namespace FPS.Model
{
    public sealed class CharacterRecoilRotation : IRotation
    {
        private readonly IRotation _head;
        private readonly IRotation _body;

        public CharacterRecoilRotation(IRotation head, IRotation body)
        {
            _head = head.ThrowExceptionIfArgumentNull(nameof(head));
            _body = body.ThrowExceptionIfArgumentNull(nameof(body));
        }

        public Vector3 Euler => new(_head.Euler.x, _body.Euler.y);

        public void Rotate(Vector3 euler)
        {
            _head.Rotate(new Vector3(-euler.x, 0));
            _body.Rotate(new Vector3(0, euler.y));
        }
    }
}