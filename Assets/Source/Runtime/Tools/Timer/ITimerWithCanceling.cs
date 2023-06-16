namespace FPS.Tools
{
    public interface ITimerWithCanceling : ITimer
    {
        bool Canceled { get; }
        void Cancel();
    }
}