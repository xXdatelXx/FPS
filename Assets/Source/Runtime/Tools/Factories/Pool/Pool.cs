using System.Collections.Generic;
using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.Tools.Factories.Pool
{
    public sealed class Pool<T> : IPool<T> where T : IPoolObject
    {
        private readonly IFactory<T> _factory;
        private readonly Stack<T> _objects;

        public Pool(IFactory<T> factory, Stack<T> objects = null)
        {
            _factory = factory.ThrowExceptionIfArgumentNull(nameof(factory));
            _objects = objects ?? new();
        }

        public T Get()
        {
            var obj = _objects.Count == 0 ? _factory.Create() : _objects.Pop();
            obj.Activate();

            return obj;
        }

        public void Return(T obj)
        {
            obj.ThrowExceptionIfArgumentNull(nameof(obj));

            obj.Deactivate();
            _objects.Push(obj);
        }
    }
}