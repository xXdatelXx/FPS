using FPS.Tools;
using UnityEngine;

namespace FPS.EntryPoint
{
    [DisallowMultipleComponent]
    public sealed class MenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private Scene _game;
        [SerializeField] private UnityButton _play;

        private void Start() => 
            _play.Subscribe(new SceneLoadButton(_game));
    }
}