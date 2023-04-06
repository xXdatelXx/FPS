using FPS.Tools.GameLoop;

namespace FPS.Model
{
    public interface IPlayerWithWeapon : IGameLoopObject
    {
        void Enable();
        void Disable();
    }
}