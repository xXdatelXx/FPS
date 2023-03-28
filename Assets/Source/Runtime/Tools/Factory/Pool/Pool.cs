using System;
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

        public bool Contains(T obj) => _objects.Contains(obj);

        public T Get() =>
            _objects.Count == 0 ? _factory.Create() : _objects.Pop();

        public void Return(T obj)
        {
            if (Contains(obj))
                throw new InvalidOperationException(nameof(Contains));

            _objects.Push(obj.ThrowExceptionIfArgumentNull(nameof(obj)));
        }
    }
}