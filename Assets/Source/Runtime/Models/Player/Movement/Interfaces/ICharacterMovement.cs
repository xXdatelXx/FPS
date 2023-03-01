using UnityEngine;

namespace FPS.Model
{
    public interface ICharacterMovement : ICharacterJump, IGravitation
    {
        void Move(Vector3 direction, float deltaTime);
    }
}