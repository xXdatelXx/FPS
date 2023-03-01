namespace FPS.Data
{
    public interface IWeaponWithMagazineData : IWeaponData
    {
        float Reload { get; }
        int Bullets { get; }
    }
}