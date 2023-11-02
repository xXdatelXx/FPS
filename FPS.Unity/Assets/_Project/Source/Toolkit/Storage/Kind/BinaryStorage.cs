using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FPS.Toolkit.Storage
{
    public sealed class BinaryStorage<TValue> : IStorage<TValue>
    {
        private readonly BinaryFormatter _formatter;
        private readonly string _pathName;

        public BinaryStorage(string fileName) : this(new DataSavePath(fileName))
        { }

        public BinaryStorage(DataSavePath path)
        {
            _pathName = path.Value;
            _formatter = new BinaryFormatter();
        }

        public bool Exists => File.Exists(_pathName);

        public TValue Load()
        {
            if (Exists == false)
                throw new HasNotSaveException(nameof(TValue), _pathName);

            using var file = File.Open(_pathName, FileMode.Open);
            return (TValue)_formatter.Deserialize(file);
        }

        public void Save(TValue value)
        {
            using var file = File.Create(_pathName);
            _formatter.Serialize(file, value);
        }
    }
}