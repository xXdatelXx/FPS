namespace FPS.GamePlay
{
    public interface IScore : IReadOnlyScore
    {
        void Increase(int value);
    }
}