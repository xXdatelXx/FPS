using UnityEngine;

namespace Source.Runtime.Models.Player.Movement.Interfaces
{
    public interface ICharacterMovement : ICharacterJump, IGravitation
    {
        void Move(Vector3 direction, float deltaTime);
    }
}