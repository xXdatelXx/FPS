using FPS.Toolkit.GameLoop;

namespace FPS.GamePlay
{
    public interface ICharacterJump : IGameLoopObject
    {
        bool Jumping { get; }
        bool CanJump { get; }

        void Jump();
    }
}