namespace Source.Runtime.Models.Weapons.Kind.Interfaces
{
    public interface IWeaponWithMagazine : IWeapon
    {
        bool CanReload { get; }
        void Reload();
    }
}