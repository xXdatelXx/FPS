using UnityEngine;

namespace FPS.GamePlay
{
    public interface ICharacterMovement : ICharacterJump, IGravitation
    {
        void Move(Vector3 direction, float deltaTime);
    }
}