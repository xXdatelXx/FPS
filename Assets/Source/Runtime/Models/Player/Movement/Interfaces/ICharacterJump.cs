namespace FPS.Model
{
    public interface ICharacterJump
    {
        bool Jumping { get; }
        bool CanJump { get; }

        void Jump();
    }
}