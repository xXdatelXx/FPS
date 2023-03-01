using Cysharp.Threading.Tasks;

namespace FPS.Tools
{
    public interface ITimer
    {
        bool Playing { get; }
        void Play();
        UniTask End();
        void Cancel();
    }
}