using FPS.Toolkit.GameLoop;

namespace FPS.GamePlay
{
    public interface IPlayerWithWeapon : IGameLoopObject
    {
        void Enable();
        void Disable();
    }
}