namespace Source.Runtime.Models.Loop
{
    public interface IGameTime : IReadOnlyGameTime
    {
        void Stop();
        void Enable();
    }
}