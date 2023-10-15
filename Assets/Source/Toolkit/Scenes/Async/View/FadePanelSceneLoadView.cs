namespace FPS.Toolkit.View
{
    public sealed class FadePanelSceneLoadView : ISceneLoadView
    {
        private readonly IFadePanel _fadePanel;

        public FadePanelSceneLoadView(IFadePanel fadePanel) => 
            _fadePanel = fadePanel.ThrowExceptionIfArgumentNull(nameof(fadePanel));

        public void VisualizeLoad() => _fadePanel.FadeIn();
    }
}