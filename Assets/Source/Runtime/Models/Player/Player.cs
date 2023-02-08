using FPS.Model.Rotation;
using FPS.Model.Weapon;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model
{
    public sealed class Player : IPlayer
    {
        private readonly ICharacterMovement _movement;
        private readonly ICharacterRotation _rotation;
        private readonly IPlayerMovementInput _input;

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