namespace FPS.Model
{
    public interface IMagazine : IReadOnlyMagazine
    {
        bool CanGet { get; }
        bool CanReset { get; }
        void Get();
        void Reset();
    }
}