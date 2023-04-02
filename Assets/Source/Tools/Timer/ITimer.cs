namespace FPS.Tools
{
    public interface ITimer : IReadOnlyTimer
    {
        bool Canceled { get; }

        void Play();
        void Cancel();
    }
}