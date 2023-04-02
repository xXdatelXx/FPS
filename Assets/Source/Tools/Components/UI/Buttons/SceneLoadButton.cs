namespace FPS.Tools
{
    public sealed class SceneLoadButton : IButton
    {
        private readonly IScene _scene;

        public SceneLoadButton(IScene scene) => 
            _scene = scene.ThrowExceptionIfArgumentNull(nameof(scene));

        public void Press() => _scene.Load();
    }
}