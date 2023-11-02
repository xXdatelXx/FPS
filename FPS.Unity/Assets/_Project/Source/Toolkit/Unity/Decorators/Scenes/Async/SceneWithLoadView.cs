using FPS.Toolkit.View;

namespace FPS.Toolkit
{
    public sealed class SceneWithLoadView : IScene
    {
        private readonly IAsyncScene _scene;
        private readonly ISceneLoadView _loadView;

        public SceneWithLoadView(IAsyncScene scene, ISceneLoadView loadView)
        {
            _scene = scene.ThrowExceptionIfArgumentNull(nameof(scene));
            _loadView = loadView.ThrowExceptionIfArgumentNull(nameof(loadView));
        }

        public void Load()
        {
            _loadView.VisualizeLoad();
            _scene.Load();
        }
    }
}