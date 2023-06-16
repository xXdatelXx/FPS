using UnityEngine;

namespace FPS.Model
{
    public interface IMovementWithTeleport : IMovement
    {
        void TeleportTo(Vector3 position);
    }
}