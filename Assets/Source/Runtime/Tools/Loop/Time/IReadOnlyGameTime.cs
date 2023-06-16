using Cysharp.Threading.Tasks;

namespace FPS.Tools.GameLoop
{
    public interface IReadOnlyGameTime
    {
        bool Active { get; }
        float FrameDelta { get; }

        UniTask NextFrame();
    }
}