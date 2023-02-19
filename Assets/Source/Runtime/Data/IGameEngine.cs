using Source.Runtime.Models.Factory.Character;
using Source.Runtime.Models.Factory.Character.Weapon;

namespace Source.Runtime.Data
{
    public interface IGameEngine
    {
        IPlayerFactory PlayerFactory { get; }
        IPlayerWeaponCollectionFactory PlayerWeaponFactory { get; }
    }
}