using System.IO;

namespace FPS.Toolkit.Storage
{
    public readonly struct DataSavePath
    {
        public readonly string Value;
        private const string SavesDirectoryName = "GameSaves";

        public DataSavePath(string fileName)
        {
            fileName.ThrowExceptionIfArgumentNull(nameof(fileName));

#if UNITY_ANDROID && !UNITY_EDITOR
            var rootDirectory = Application.persistentDataPath;
#else
            var rootDirectory = string.Empty;
#endif
            var directory = rootDirectory + SavesDirectoryName;
            Value = Path.Combine(directory, fileName);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }
    }
}