namespace FPS.Toolkit
{
    public interface ITimerWithCanceling : ITimer
    {
        bool Canceled { get; }
        void Cancel();
    }
}