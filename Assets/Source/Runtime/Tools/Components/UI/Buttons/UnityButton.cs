using UnityEngine;
using UnityEngine.UI;

namespace FPS.Tools
{
    [RequireComponent(typeof(Button))]
    public sealed class UnityButton : MonoBehaviour, IUnityButton
    {
        private IButton _button;
        private Button _unityButton;

        private void Awake() => 
            _unityButton = GetComponent<Button>();

        public void Subscribe(IButton button)
        {
            _button = button.ThrowExceptionIfArgumentNull(nameof(button));
            _unityButton.onClick.AddListener(button.Press);
        }

        private void OnDestroy() => 
            _unityButton.onClick.RemoveListener(_button.Press);
    }
}