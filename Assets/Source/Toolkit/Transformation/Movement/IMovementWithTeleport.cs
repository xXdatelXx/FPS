using UnityEngine;

namespace FPS.Toolkit
{
    public interface IMovementWithTeleport : IMovement
    {
        void TeleportTo(Vector3 position);
    }
}