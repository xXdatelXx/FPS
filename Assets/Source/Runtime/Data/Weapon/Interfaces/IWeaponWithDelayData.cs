namespace FPS.Data
{
    public interface IWeaponWithDelayData : IWeaponData
    {
        float Delay { get; }
    }
}