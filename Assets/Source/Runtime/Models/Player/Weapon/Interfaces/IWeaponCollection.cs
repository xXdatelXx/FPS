namespace FPS.Model
{
    public interface IWeaponCollection : IReadOnlyWeaponCollection
    {
        void Add(IPlayerWithWeapon weapon);
        void Remove(IPlayerWithWeapon weapon);
    }
}