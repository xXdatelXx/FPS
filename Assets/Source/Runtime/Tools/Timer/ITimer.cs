using Cysharp.Threading.Tasks;

namespace Source.Runtime.Model.Timer
{
    public interface ITimer
    {
        bool Playing { get; }
        void Play();
        UniTask End();
    }
}