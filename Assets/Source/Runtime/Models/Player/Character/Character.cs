using FPS.Tools;

namespace FPS.Model
{
    public sealed class Character : ICharacter
    {
        public Character(ICharacterMovement movement, ICharacterRotation rotation)
        {
            Movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            Rotation = rotation.ThrowExceptionIfArgumentNull(nameof(rotation));
        }

        public ICharacterMovement Movement { get; }
        public ICharacterRotation Rotation { get; }
        
        public void Tick(float deltaTime) => Movement.Tick(deltaTime);
    }
}