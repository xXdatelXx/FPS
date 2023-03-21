using FPS.Input;
using FPS.Tools;

namespace FPS.Model
{
    public sealed class Player : IPlayer
    {
        private readonly IPlayerTransformInput _input;
        private readonly ICharacterMovement _movement;
        private readonly ICharacterRotation _rotation;

        public Player(ICharacterMovement movement, ICharacterRotation rotation, IPlayerTransformInput input)
        {
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            _rotation = rotation.ThrowExceptionIfArgumentNull(nameof(rotation));
            _input = input.ThrowExceptionIfArgumentNull(nameof(input));
        }

        public void Tick(float deltaTime)
        {
            _movement.Tick(deltaTime);

            if (_input.Jump() && _movement.CanJump)
                _movement.Jump();

            if (_input.Moving)
                _movement.Move(_input.Movement(), deltaTime);

            if (_input.Rotating)
                _rotation.Rotate(_input.Rotation());

            if (_movement.CanGravitate)
                _movement.Gravitate(deltaTime);
        }
    }
}