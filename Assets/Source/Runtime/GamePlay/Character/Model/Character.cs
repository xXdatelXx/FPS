using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class Character : ICharacter
    {
        public Character(ICharacterMovement movement, ICharacterRotation rotation, IHealth health, IScore score)
        {
            Movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            Rotation = rotation.ThrowExceptionIfArgumentNull(nameof(rotation));
            Health = health.ThrowExceptionIfArgumentNull(nameof(health));
            Score = score.ThrowExceptionIfArgumentNull(nameof(score));
        }

        public ICharacterMovement Movement { get; }
        public ICharacterRotation Rotation { get; }
        public IHealth Health { get; }
        public IScore Score { get; }

        public void Tick(float deltaTime) => Movement.Tick(deltaTime);
    }
}