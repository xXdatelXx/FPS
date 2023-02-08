namespace FPS.Model.Weapons.Bullet
{
    public interface IMagazine : IReadOnlyMagazine
    {
        void Get();
        bool CanShoot { get; }
        bool CanReload { get; }
        void Reload();
    }
}