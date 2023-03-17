namespace FPS.Tools
{
    public interface IPool<T>
    {
        bool Contains(T obj);
        T Get();
        void Return(T obj);
    }
}