using FPS.Toolkit.Storage;
using FPS.Toolkit.Tests.Dummys;
using NUnit.Framework;

namespace FPS.Toolkit.Tests
{
    internal sealed class PlayerPrefsStorageTest
    {
        [Test]
        public void SavesCorrectly()
        {
            var data = new DummySaveData(43, nameof(PlayerPrefsStorageTest));
            var storage = new PlayerPrefsStorage<DummySaveData>(new DummySavePath());
            var test = new StorageTest(storage, data);

            test.SavesCorrectly();
        }
    }
}