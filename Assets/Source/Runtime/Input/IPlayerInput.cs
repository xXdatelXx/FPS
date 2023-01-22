using UnityEngine;

namespace FPS.Model
{
    public interface IPlayerInput
    {
        bool Moving { get; }
        bool Rotating { get; }
        Vector3 Movement();
        Vector3 Rotation();
        bool Jump();
    }
}