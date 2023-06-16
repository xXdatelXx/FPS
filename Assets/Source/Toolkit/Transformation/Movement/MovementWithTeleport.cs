using UnityEngine;

namespace FPS.Toolkit
{
    public sealed class MovementWithTeleport : IMovementWithTeleport
    {
        private readonly IMovement _movement;
        private readonly IPosition _position;

        public MovementWithTeleport(IPosition position, IMovement movement)
        {
            _position = position.ThrowExceptionIfArgumentNull(nameof(position));
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
        }

        public Vector3 Position => _movement.Position;

        public void Move(Vector3 motion) => _movement.Move(motion);

        public void TeleportTo(Vector3 position) => _position.TeleportTo(position);
    }
}