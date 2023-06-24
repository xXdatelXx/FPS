using System;
using FPS.Toolkit;
using FPS.Toolkit.Storage;

namespace FPS.Input
{
    public sealed class MouseSensitivity : IMouseSensitivity
    {
        private readonly IStorage<float> _storage;

        public MouseSensitivity()
        {
            _storage = new BinaryStorage<float>(nameof(MouseSensitivity));

            if (_storage.NullOrDefault()) 
                _storage.Save(1);

            Value = _storage.Load();
            Value.ThrowExceptionIfValueSubOrEqualZero(nameof(MouseSensitivity));
        }

        public float Value { get; private set; }

        public void Update(float value)
        {
            if (value.Equals(Value))
                throw new InvalidOperationException(nameof(Update));

            value.ThrowExceptionIfValueSubZero(nameof(MouseSensitivity));

            Value = value;
            _storage.Save(Value);
        }
    }
}