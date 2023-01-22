namespace Source.Runtime.Models.Loop
{
    public interface IReadOnlyGameTime
    {
        bool Active { get; }
        float FixedDelta { get; }
        float Delta { get; }
    }
}