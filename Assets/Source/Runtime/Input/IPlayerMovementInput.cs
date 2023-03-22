using UnityEngine;

namespace FPS.Input
{
    public interface IPlayerMovementInput
    {
        bool IsMoving { get; }
        bool IsRotating { get; }
        bool IsJumping { get; }
        Vector3 GetMovementInput();
        Vector3 GetRotationInput();
    }
}