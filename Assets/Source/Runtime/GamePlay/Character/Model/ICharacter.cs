namespace FPS.GamePlay
{
    public interface ICharacter
    {
        ICharacterMovement Movement { get; }
        ICharacterRotation Rotation { get; }
        IHealth Health { get; }

        void Tick(float deltaTime);
    }
}