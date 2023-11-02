namespace FPS.Toolkit
{
    public interface IFactory<out T>
    {
        T Create();
    }
}