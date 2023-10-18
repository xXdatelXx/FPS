namespace FPS.Toolkit
{
    public interface IFadePanel
    {
        float FadeTime { get; }
        
        void FadeIn();
        void FadeOut();
    }
}