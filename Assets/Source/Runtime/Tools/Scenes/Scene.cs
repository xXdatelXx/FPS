using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPS.Tools
{
    [CreateAssetMenu(menuName = "Scenes/Scene")]
    public sealed class Scene : ScriptableObject, ISerializationCallbackReceiver, IScene
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset _scene;
#endif

        public Scene(string name)
        {
            Name = name.ThrowExceptionIfArgumentNull(nameof(name));
            Validate();
        }

        [field: SerializeField] public string Name { get; private set; }

        #region Serialize

        public void OnAfterDeserialize()
        {
        }

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            if (_scene != null)
            {
                Name = _scene.name;
                Validate();
            }
#endif
        }

        #endregion

        public void Load() => SceneManager.LoadScene(Name);

        private void Validate()
        {
            if (!SceneManager.GetSceneByName(name).IsValid())
                throw new ArgumentException($"{name} not exists");
        }
    }
}