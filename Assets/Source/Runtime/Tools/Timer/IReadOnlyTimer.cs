using Cysharp.Threading.Tasks;

namespace FPS.Tools
{
    public interface IReadOnlyTimer
    {
        bool Playing { get; }
        UniTask End();
    }
}