using Source.Runtime.Input;
using Source.Runtime.Models.Player.Movement.Interfaces;
using Source.Runtime.Models.Player.Rotation;
using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.Models.Player
{
    public sealed class Player : IPlayer
    {
        private readonly IPlayerMovementInput _input;
        private readonly ICharacterMovement _movement;
        private readonly ICharacterRotation _rotation;

        public Player(ICharacterMovement movement, ICharacterRotation rotation, IPlayerMovementInput input)
        {
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            _rotation = rotation.ThrowExceptionIfArgumentNull(nameof(rotation));
            _input = input.ThrowExceptionIfArgumentNull(nameof(input));
        }

        public void Tick(float deltaTime)
        {
            if (_input.Moving)
                _movement.Move(_input.Movement(), deltaTime);

            if (_input.Rotating)
                _rotation.Rotate(_input.Rotation());

            if (_input.Jump() && _movement.CanJump)
                _movement.Jump();

            if (_movement.CanGravitate)
                _movement.Gravitate(deltaTime);
        }
    }
}