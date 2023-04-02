using FPS.Input;
using FPS.Tools;

namespace FPS.Model
{
    public sealed class Player : IPlayer
    {
        private readonly IPlayerMovementInput _input;
        private readonly ICharacter _character;

        public Player(ICharacter character, IPlayerMovementInput input)
        {
            _character = character.ThrowExceptionIfArgumentNull(nameof(character));
            _input = input.ThrowExceptionIfArgumentNull(nameof(input));
        }

        public void Tick(float deltaTime)
        {
            _character.Tick(deltaTime);

            if (_input.Jump() && _character.Movement.CanJump)
                _character.Movement.Jump();

            if (_input.Moving)
                _character.Movement.Move(_input.Movement(), deltaTime);

            if (_input.Rotating)
                _character.Rotation.Rotate(_input.Rotation());
        }
    }
}