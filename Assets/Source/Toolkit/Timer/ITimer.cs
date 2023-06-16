namespace FPS.Toolkit
{
    public interface ITimer : IReadOnlyTimer
    {
        void Play();
        void Stop();
    }
}