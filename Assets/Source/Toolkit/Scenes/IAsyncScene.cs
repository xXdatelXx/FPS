using Cysharp.Threading.Tasks;

namespace FPS.Toolkit
{
    public interface IAsyncScene
    {
        UniTask Load();
    }
}