using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class Character : ICharacter
    {
        public Character(ICharacterMovement movement, ICharacterRotation rotation, IHealth health)
        {
            Movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            Rotation = rotation.ThrowExceptionIfArgumentNull(nameof(rotation));
            Health = health.ThrowExceptionIfArgumentNull(nameof(health));
        }

        public ICharacterMovement Movement { get; }
        public ICharacterRotation Rotation { get; }
        public IHealth Health { get; }

        public void Tick(float deltaTime) => Movement.Tick(deltaTime);
    }
}