namespace FPS.Game
{
    public interface IGameTime : IReadOnlyGameTime
    {
        void Stop();
        void Enable();
    }
}