namespace FPS.GamePlay
{
    public interface IReadOnlyHealth
    {
        bool Died { get; }
        float Points { get; }
    }
}