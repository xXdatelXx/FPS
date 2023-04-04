namespace FPS.Model
{
    public interface ICharacter
    {
        ICharacterMovement Movement { get; }
        ICharacterRotation Rotation { get; }
        
        void Tick(float deltaTime);
    }
}