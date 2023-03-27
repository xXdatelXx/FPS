using FPS.Tools.GameLoop;

namespace FPS.Model
{
    public interface ICharacterJump : ITickable
    {
        bool Jumping { get; }
        bool CanJump { get; }

        void Jump();
    }
}