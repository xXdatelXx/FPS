using FPS.Toolkit.Storage;
using FPS.Toolkit.Tests.Dummys;
using NUnit.Framework;

namespace FPS.Toolkit.Tests
{
    internal sealed class StorageTest
    {
        private readonly IStorage<DummySaveData> _storage;
        private readonly DummySaveData _value;

        public StorageTest(IStorage<DummySaveData> storage, DummySaveData value)
        {
            _storage = storage.ThrowExceptionIfArgumentNull(nameof(storage));
            _value = value.ThrowExceptionIfArgumentNull(nameof(value));
        }

        public void SavesCorrectly()
        {
            _storage.Save(_value);
            var loadedValue = _storage.Load();

            Assert.That(loadedValue.Id == _value.Id && loadedValue.Name == _value.Name);
        }
    }
}