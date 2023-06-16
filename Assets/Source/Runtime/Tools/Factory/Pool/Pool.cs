using System;
using System.Collections.Generic;

namespace FPS.Tools
{
    public sealed class Pool<TItem> : IPool<TItem>
    {
        private readonly IFactory<TItem> _factory;
        private readonly Stack<TItem> _objects;

        public Pool(IFactory<TItem> factory, Stack<TItem> objects = null)
        {
            _factory = factory.ThrowExceptionIfArgumentNull(nameof(factory));
            _objects = objects ?? new();
        }

        public bool Contains(TItem obj) => _objects.Contains(obj);

        public TItem Get() =>
            _objects.Count == 0 ? _factory.Create() : _objects.Pop();

        public void Return(TItem obj)
        {
            if (Contains(obj))
                throw new InvalidOperationException(nameof(Contains));

            _objects.Push(obj.ThrowExceptionIfArgumentNull(nameof(obj)));
        }
    }
}