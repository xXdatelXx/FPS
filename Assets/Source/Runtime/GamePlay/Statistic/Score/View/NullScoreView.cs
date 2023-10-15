namespace FPS.GamePlay
{
    public sealed class NullScoreView : IScoreView
    {
        public void Visualize(int value)
        { }

        public void VisualizeNewMaxScore(int value)
        { }
    }
}