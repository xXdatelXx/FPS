using FPS.Model.Weapons;

namespace FPS.Model.Weapon
{
    public interface IWeaponCollection<TWeapon> : IReadOnlyWeaponCollection<TWeapon> where TWeapon : IWeapon
    {
        void Add(TWeapon weapon);
        void Remove(TWeapon weapon);
    }
}