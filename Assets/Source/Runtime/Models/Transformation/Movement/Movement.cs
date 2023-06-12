using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class Movement : IMovement
    {
        private readonly IPosition _position;

        public Movement(IPosition position) =>
            _position = position.ThrowExceptionIfArgumentNull(nameof(position));

        public Vector3 Position => _position.Value;

        public void Move(Vector3 motion) => _position.TeleportTo(_position.Value + motion);
    }
}