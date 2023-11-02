using UnityEngine;

namespace FPS.Toolkit.Storage
{
    public sealed class PlayerPrefsStorage<TValue> : IStorage<TValue>
    {
        private readonly string _pathName;

        public PlayerPrefsStorage(string fileName) : this(new DataSavePath(fileName))
        { }

        public PlayerPrefsStorage(DataSavePath path)
        {
            path.ThrowExceptionIfArgumentNull(nameof(path));
            _pathName = path.Value;
        }

        public bool Exists => PlayerPrefs.HasKey(_pathName);

        public TValue Load()
        {
            if (Exists == false)
                throw new HasNotSaveException(nameof(TValue), _pathName);

            var loadJson = PlayerPrefs.GetString(_pathName);
            return JsonUtility.FromJson<TValue>(loadJson);
        }

        public void Save(TValue value)
        {
            value.ThrowExceptionIfArgumentNull(nameof(value));

            var saveJson = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(_pathName, saveJson);
        }
    }
}