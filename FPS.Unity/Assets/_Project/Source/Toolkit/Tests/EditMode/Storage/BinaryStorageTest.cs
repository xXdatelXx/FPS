using FPS.Toolkit.Storage;
using FPS.Toolkit.Tests.Dummys;
using NUnit.Framework;

namespace FPS.Toolkit.Tests
{
    internal sealed class BinaryStorageTest
    {
        [Test]
        public void SavesCorrectly()
        {
            var data = new DummySaveData(10, nameof(BinaryStorageTest));
            var storage = new BinaryStorage<DummySaveData>(new DataSavePath("TestStorage"));
            var test = new StorageTest(storage, data);

            test.SavesCorrectly();
        }
    }
}