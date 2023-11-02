using Cysharp.Threading.Tasks;

namespace FPS.Toolkit.GameLoop
{
    public interface IReadOnlyGameTime
    {
        bool Active { get; }
        float FrameDelta { get; }

        UniTask NextFrame();
    }
}