using UnityEngine;

namespace FPS.Toolkit
{
    public sealed class Movement : IMovement
    {
        private readonly IPosition _position;

        public Movement(IPosition position) =>
            _position = position.ThrowExceptionIfArgumentNull(nameof(position));

        public IReadOnlyPosition Position => _position;

        public void Move(Vector3 motion) => _position.TeleportTo(_position.Value + motion);
    }
}