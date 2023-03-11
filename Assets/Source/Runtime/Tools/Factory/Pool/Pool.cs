using System.Collections.Generic;

namespace FPS.Tools
{
    public sealed class Pool<T> : IPool<T>
    {
        private readonly IFactory<T> _factory;
        private readonly Stack<T> _objects;

        public Pool(IFactory<T> factory, Stack<T> objects = null)
        {
            _factory = factory.ThrowExceptionIfArgumentNull(nameof(factory));
            _objects = objects ?? new();
        }

        public T Get() => 
            _objects.Count == 0 ? _factory.Create() : _objects.Pop();

        public void Return(T obj) => 
            _objects.Push(obj.ThrowExceptionIfArgumentNull(nameof(obj)));
    }
}