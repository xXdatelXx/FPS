namespace Source.Runtime.Models.Game.Loop.Time
{
    public interface IGameTime : IReadOnlyGameTime
    {
        void Stop();
        void Enable();
    }
}