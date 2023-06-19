using System.IO;
using UnityEngine;

namespace FPS.Toolkit.Storage
{
    public sealed class Path : IPath
    {
        public Path(string name)
        {
            name.ThrowExceptionIfArgumentNull(nameof(name));
            
#if UNITY_ANDROID && !UNITY_EDITOR
            var folder = Application.persistentDataPath + "Game Saves";
            Name = System.IO.Path.Combine(Application.persistentDataPath, SavesFolder, name);
#else
            var folder = Application.dataPath + "Game Saves";
            Name = System.IO.Path.Combine(Application.dataPath, folder, name);
#endif

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }

        public string Name { get; }
    }
}