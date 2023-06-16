using FPS.Tools;
using UnityEngine;

namespace FPS.Data.Scenes
{
    [CreateAssetMenu(fileName = nameof(Scenes), menuName = nameof(Scenes))]
    public sealed class Scenes : ScriptableObject, IScenes
    {
        [SerializeField] private Scene _menu;
        [SerializeField] private Scene _game;

        public IScene Menu => _menu;
        public IScene Game => _game;
    }
}