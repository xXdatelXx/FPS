namespace Source.Runtime.Models.Weapons.Magazine
{
    public interface IMagazine : IReadOnlyMagazine
    {
        bool CanGet { get; }
        bool CanReset { get; }
        void Get();
        void Reset();
    }
}