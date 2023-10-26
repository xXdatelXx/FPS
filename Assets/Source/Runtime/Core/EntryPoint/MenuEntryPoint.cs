using FPS.Input;
using FPS.Toolkit;
using FPS.Toolkit.View;
using FPS.Ui;
using Sirenix.OdinInspector;
using UnityEngine;
using GameObject = FPS.Toolkit.GameObject;

namespace FPS.Core
{
    [DisallowMultipleComponent]
    public sealed class MenuEntryPoint : MonoBehaviour
    {
        [Header("Play button")] 
        [SerializeField] private Scene _game;
        [SerializeField] private UnityButton _play;
        [SerializeField, MinValue(0)] private float _timeToSwitchScene;
        [SerializeField] private AnimationSceneLoadView _sceneLoadView;
        [Header("Options")] 
        [SerializeField] private UnityButton _options;
        [SerializeField] private UnitySlider _sensitivity;

        private void Start()
        {
            SetupPlayButton();
            SetupOptions();

            new GameCursor().Show();
        }

        private void SetupPlayButton()
        {
            var asyncLoadGameScene = new AsyncScene(_game, _timeToSwitchScene);
            var sceneWithLoadView = new SceneWithLoadView(asyncLoadGameScene, _sceneLoadView);
            _play.Subscribe(new SceneLoadButton(sceneWithLoadView));
        }

        private void SetupOptions()
        {
            var optionsToggleActiveButton = new GameObjectActivationButton(new GameObject(_sensitivity.gameObject));
            _options.Subscribe(optionsToggleActiveButton);

            var sensitivity = new MouseSensitivity();
            _sensitivity.Subscribe(new MouseSensitivitySlider(sensitivity), sensitivity.Value);
        }
    }
}