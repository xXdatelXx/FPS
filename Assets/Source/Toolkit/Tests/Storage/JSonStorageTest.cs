using FPS.Toolkit.Storage;
using FPS.Toolkit.Tests.Dummys;
using NUnit.Framework;

namespace FPS.Toolkit.Tests
{
    internal sealed class JSonStorageTest
    {
        [Test]
        public void SavesCorrectly()
        {
            var data = new DummySaveData(23, nameof(JSonStorageTest));
            var storage = new JsonStorage<DummySaveData>(new DummySavePath());
            var test = new StorageTest(storage, data);

            test.SavesCorrectly();
        }
    }
}