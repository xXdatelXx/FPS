namespace FPS.Game
{
    public interface IReadOnlyGameTime
    {
        bool Active { get; }
        float FixedDelta { get; }
        float Delta { get; }
    }
}