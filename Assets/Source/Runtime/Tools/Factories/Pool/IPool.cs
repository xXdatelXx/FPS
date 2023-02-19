namespace Source.Runtime.Tools.Factories.Pool
{
    public interface IPool<T> where T : IPoolObject
    {
        T Get();
        void Return(T obj);
    }
}