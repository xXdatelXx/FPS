namespace FPS.Model.Weapon
{
    public interface IWeaponCollection : IReadOnlyWeaponCollection
    {
        void Add(IPlayerWeapon weapon);
        void Remove(IPlayerWeapon weapon);
    }
}