using FPS.Toolkit.GameLoop;

namespace FPS.Model
{
    public interface ICharacterJump : IGameLoopObject
    {
        bool Jumping { get; }
        bool CanJump { get; }

        void Jump();
    }
}