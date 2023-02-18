namespace FPS.Model.Weapons.Bullet
{
    public interface IMagazine : IReadOnlyMagazine
    {
        bool CanGet { get; }
        void Get();
        bool CanReset { get; }
        void Reset();
    }
}