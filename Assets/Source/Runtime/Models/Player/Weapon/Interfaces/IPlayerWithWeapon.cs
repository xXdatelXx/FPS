using FPS.Tools.GameLoop;

namespace FPS.Model
{
    public interface IPlayerWithWeapon : ITickable
    {
        void Enable();
        void Disable();
    }
}