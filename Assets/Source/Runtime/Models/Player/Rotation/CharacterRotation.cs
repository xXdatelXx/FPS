using System;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace Source.Runtime.Models.Player.Rotation
{
    public class CharacterRotation : ICharacterRotation
    {
        private readonly IBodyRotation _body;
        private readonly IHeadRotation _head;
        private readonly Vector2 _sensitivity;

        public CharacterRotation(IBodyRotation body, IHeadRotation head, Vector2 sensitivity)
        {
            _body = body.ThrowExceptionIfArgumentNull(nameof(body));
            _head = head.ThrowExceptionIfArgumentNull(nameof(head));
            _sensitivity = sensitivity;
        }

        public void Rotate(Vector3 direction)
        {
            if (direction == Vector3.zero)
                throw new InvalidOperationException(nameof(direction) + " empty");

            _head.Rotate(direction.x * _sensitivity.x);
            _body.Rotate(direction.y * _sensitivity.y);
        }
    }
}