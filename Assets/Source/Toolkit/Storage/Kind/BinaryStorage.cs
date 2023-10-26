using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FPS.Toolkit.Storage
{
    public sealed class BinaryStorage<TValue> : IStorage<TValue>
    {
        private readonly BinaryFormatter _formatter;
        private readonly string _pathName;

        public BinaryStorage(IPath path) : this(path.Name)
        { }

        public BinaryStorage(string name)
        {
            _pathName = name.ThrowExceptionIfArgumentNull(nameof(name));
            _formatter = new();
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