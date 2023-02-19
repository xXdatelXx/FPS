namespace Source.Runtime.Models.Game.Loop.Time
{
    public interface IReadOnlyGameTime
    {
        bool Active { get; }
        float FixedDelta { get; }
        float Delta { get; }
    }
}