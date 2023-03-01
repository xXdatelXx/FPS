using FPS.Game.Loop;

namespace FPS.Model
{
    public interface IPlayerWithWeapon : ITickable
    {
        void Enable();
        void Disable();
    }
}