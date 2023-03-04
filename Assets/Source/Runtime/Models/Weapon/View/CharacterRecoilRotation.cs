using FPS.Tools;
using FPS.Views;
using UnityEngine;

namespace FPS.Model
{
    public sealed class CharacterRecoilRotation : IGameObjectWithRotation
    {
        private readonly IGameObjectWithRotation _head;
        private readonly IGameObjectWithRotation _body;

        public CharacterRecoilRotation(IGameObjectWithRotation head, IGameObjectWithRotation body)
        {
            _head = head.ThrowExceptionIfArgumentNull(nameof(head));
            _body = body.ThrowExceptionIfArgumentNull(nameof(body));
        }

        public Vector3 Rotation => new(_head.Rotation.x, _body.Rotation.y);

        public void Rotate(Vector3 euler)
        {
            _head.Rotate(new Vector3(euler.x, 0));
            _body.Rotate(new Vector3(0, euler.y));
        }
    }
}