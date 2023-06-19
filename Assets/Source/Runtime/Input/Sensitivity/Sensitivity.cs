using System;
using FPS.Toolkit;
using FPS.Toolkit.Storage;
using UnityEngine;

namespace FPS.Input
{
    [Serializable]
    public sealed class Sensitivity : ISensitivity
    {
        private readonly IStorage<Vector2> _storage;

        public Sensitivity()
        {
            _storage = new JsonStorage<Vector2>(nameof(Sensitivity));

            if (!_storage.Exists)
                _storage.Save(Vector2.one);

            Value = _storage.Load();

            if (Value.x < 0 || Value.y < 0)
                throw new SubZeroException("Sensitivity in storage");
        }

        public Vector2 Value { get; private set; }

        public void Update(Vector2 value)
        {
            if (value == Value)
                throw new InvalidOperationException(nameof(Update));
            if (Value.x < 0 || Value.y < 0)
                throw new SubZeroException(nameof(Sensitivity));

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