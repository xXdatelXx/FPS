namespace FPS.Tools.GameLoop
{
    public interface IGameTime : IReadOnlyGameTime
    {
        void Stop();
        void Enable();
    }
}