namespace FPS.GamePlay
{
    public interface ILoseFactory
    {
        ILoseView Create(IScore score);
    }
}