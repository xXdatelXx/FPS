using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class MovementWithTeleport : IMovementWithTeleport
    {
        private readonly Transform _transform;
        private readonly IMovement _movement;

        public MovementWithTeleport(Transform transform, IMovement movement)
        {
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
        }

        public Vector3 Position => _movement.Position;
        
        public void Move(Vector3 motion) => _movement.Move(motion);
        
        public void MoveByRotation(Vector3 motion) => _movement.MoveByRotation(motion);

        public void TeleportTo(Vector3 position) => _transform.position = position;
    }
}