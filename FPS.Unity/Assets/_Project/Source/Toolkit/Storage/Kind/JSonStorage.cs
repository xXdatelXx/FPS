using System.IO;
using UnityEngine;

namespace FPS.Toolkit.Storage
{
    public sealed class JsonStorage<TValue> : IStorage<TValue>
    {
        private readonly string _pathName;

        public JsonStorage(string fileName) : this(new DataSavePath(fileName))
        { }

        public JsonStorage(DataSavePath path)
        {
            path.ThrowExceptionIfArgumentNull(nameof(path));
            _pathName = path.Value;
        }

        public bool Exists => File.Exists(_pathName);

        public TValue Load()
        {
            if (Exists == false)
                throw new HasNotSaveException(nameof(TValue), _pathName);

            var saveJson = File.ReadAllText(_pathName);
            return JsonUtility.FromJson<TValue>(saveJson);
        }

        public void Save(TValue value)
        {
            value.ThrowExceptionIfArgumentNull(nameof(value));

            var saveJson = JsonUtility.ToJson(value);
            File.WriteAllText(_pathName, saveJson);
        }
    }
}