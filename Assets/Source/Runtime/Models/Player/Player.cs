using FPS.Input;
using FPS.Tools;

namespace FPS.Model
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
            _movement.Tick(deltaTime);

            if (_input.IsJumping && _movement.CanJump)
                _movement.Jump();

            if (_input.IsMoving)
                _movement.Move(_input.GetMovementInput(), deltaTime);

            if (_input.IsRotating)
                _rotation.Rotate(_input.GetRotationInput());

            if (_movement.CanGravitate)
                _movement.Gravitate(deltaTime);
        }
    }
}