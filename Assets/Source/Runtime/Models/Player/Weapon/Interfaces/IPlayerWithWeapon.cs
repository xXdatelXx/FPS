using Source.Runtime.Models.Game.Loop.Tickables;

namespace Source.Runtime.Models.Player.Weapon.Interfaces
{
    public interface IPlayerWithWeapon : ITickable
    {
        void Enable();
        void Disable();
    }
}