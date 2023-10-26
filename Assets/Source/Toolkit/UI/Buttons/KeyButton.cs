using UnityEngine;

namespace FPS.Toolkit
{
    public sealed class KeyButton : MonoBehaviour, IUnityButton
    {
        [SerializeField] private KeyCode _key;

        private IButton _button;

        public void Subscribe(IButton button) =>
            _button = button.ThrowExceptionIfArgumentNull(nameof(button));

        private void Update()
        {
            if (Input.GetKeyDown(_key))
                _button.Press();
        }
    }
}