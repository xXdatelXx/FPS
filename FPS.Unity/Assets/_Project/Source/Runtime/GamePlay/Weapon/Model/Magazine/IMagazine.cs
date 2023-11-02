namespace FPS.GamePlay
{
    public interface IMagazine : IReadOnlyMagazine
    {
        bool CanGet { get; }
        bool CanReload { get; }
        void Get();
        void Reload();
    }
}