namespace Source.Runtime.Models.Player.Weapon.Interfaces
{
    public interface IWeaponCollection : IReadOnlyWeaponCollection
    {
        void Add(IPlayerWithWeapon weapon);
        void Remove(IPlayerWithWeapon weapon);
    }
}