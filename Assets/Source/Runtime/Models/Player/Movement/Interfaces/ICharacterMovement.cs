using UnityEngine;

namespace FPS.Model
{
    public interface ICharacterMovement
    {
        bool CanJump { get; }
        void Move(Vector3 direction, float deltaTime);
        void Jump(float deltaTime);
        void Gravitate(float deltatime);
    }
}