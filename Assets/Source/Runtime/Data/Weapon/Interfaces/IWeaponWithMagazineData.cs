namespace Source.Runtime.Data.Weapon
{
    public interface IWeaponWithMagazineData : IWeaponData
    {
        float Reload { get; }
        int Bullets { get; }
    }
}