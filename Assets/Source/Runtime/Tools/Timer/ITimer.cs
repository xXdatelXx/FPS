using Cysharp.Threading.Tasks;

namespace Source.Runtime.Tools.Timer
{
    public interface ITimer
    {
        bool Playing { get; }
        void Play();
        UniTask End();
        void Cancel();
    }
}