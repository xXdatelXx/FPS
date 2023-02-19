namespace Source.Runtime.Data.Weapon.Interfaces
{
    public interface IWeaponWithMagazineData : IWeaponData
    {
        float Reload { get; }
        int Bullets { get; }
    }
}