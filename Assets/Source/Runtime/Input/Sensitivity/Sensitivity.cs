using System;
using FPS.Toolkit;
using FPS.Toolkit.Storage;
using UnityEngine;

namespace FPS.Input
{
    public sealed class Sensitivity : ISensitivity
    {
        private readonly IStorage<Vector2> _storage;

        public Sensitivity(IStorage<Vector2> storage)
        {
            _storage = storage.ThrowExceptionIfArgumentNull(nameof(storage));
            
            if(!_storage.Exists)
                _storage.Save(Vector2.one);
            
            Value = _storage.Load();
        }

        public Vector2 Value { get; private set; }

        public void Update(Vector2 value)
        {
            if (value == Value)
                throw new InvalidOperationException(nameof(Update));

            Value = value;
        }

        //TODO test this
        ~Sensitivity()
        {
            if (_storage.Load() != Value)
                _storage.Save(Value);
        }
    }
}