using Source.Runtime.TickSystem;

namespace FPS.Model.Weapon
{
    public interface IPlayerWeapon : ITickable
    {
        void Enable();
        void Disable();
    }
}