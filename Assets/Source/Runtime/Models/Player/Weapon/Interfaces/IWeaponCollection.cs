namespace Source.Runtime.Models.Player.Weapon.Interfaces
{
    public interface IWeaponCollection : IReadOnlyWeaponCollection
    {
        void Add(IPlayerWeapon weapon);
        void Remove(IPlayerWeapon weapon);
    }
}