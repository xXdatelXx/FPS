using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public interface ICharacterMovement : ICharacterJump, IGravitation
    {
        IReadOnlyPosition Position { get; }
        void Move(Vector3 direction, float deltaTime);
    }
}