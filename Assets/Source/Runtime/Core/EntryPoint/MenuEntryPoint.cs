using FPS.Input;
using FPS.Toolkit;
using FPS.Ui;
using UnityEngine;

namespace FPS.Core
{
    [DisallowMultipleComponent]
    public sealed class MenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private Scene _game;
        [SerializeField] private UnityButton _play;
        [SerializeField] private UnitySlider _sensitivity;

        private void Start()
        {
            _play.Subscribe(new SceneLoadButton(_game));
            var sensitivity = new MouseSensitivity();
            _sensitivity.Subscribe(new MouseSensitivitySlider(sensitivity), sensitivity.Value);
        }
    }
}