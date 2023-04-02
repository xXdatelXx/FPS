using UnityEngine;

namespace FPS.Input
{
    public interface IPlayerMovementInput
    {
        bool Moving { get; }
        bool Rotating { get; }
        Vector3 Movement();
        Vector2 Rotation();
        bool Jump();
    }
}