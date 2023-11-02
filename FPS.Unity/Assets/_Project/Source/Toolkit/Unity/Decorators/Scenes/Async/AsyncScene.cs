using Cysharp.Threading.Tasks;

namespace FPS.Toolkit
{
    // ¯\_(ツ)_/¯
    public sealed class AsyncScene : IAsyncScene
    {
        private readonly IScene _scene;
        private readonly ITimer _load;

        public AsyncScene(IScene scene, float loadSeconds) : this(scene, new AsyncTimer(loadSeconds))
        { }

        public AsyncScene(IScene scene, ITimer load)
        {
            _scene = scene.ThrowExceptionIfArgumentNull(nameof(scene));
            _load = load.ThrowExceptionIfArgumentNull(nameof(load));
        }

        public async UniTask Load()
        {
            _load.Play();
            await _load.End();
            _scene.Load();
        }
    }
}