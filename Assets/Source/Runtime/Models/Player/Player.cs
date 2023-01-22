using FPS.Model.Rotation;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model
{
    public sealed class Player : IPlayer
    {
        private readonly ICharacterMovement _movement;
        private readonly ICharacterRotation _rotation;
        private readonly IPlayerInput _input;

        public Player(ICharacterMovement movement, ICharacterRotation rotation, IPlayerInput input)
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
            
            if (_input.Jump())
                _movement.Jump(deltaTime);
            
            _movement.Gravitate(deltaTime);
        }
    }
}