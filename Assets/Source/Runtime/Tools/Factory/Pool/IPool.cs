namespace FPS.Tools
{
    public interface IPool<T>
    {
        T Get();
        void Return(T obj);
    }
}