namespace FPS.Tools
{
    public interface IPool<T> where T : IPoolObject
    {
        T Get();
        void Return(T obj);
    }
}