namespace FPS.Tools
{
    public interface ITimer : IReadOnlyTimer
    {
        void Play();
        void Stop();
    }
}