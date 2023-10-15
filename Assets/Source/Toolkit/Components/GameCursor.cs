using UnityEngine;

namespace FPS.Toolkit
{
    public sealed class GameCursor : MonoBehaviour
    {
        [SerializeField] private bool _hideOnStart;

        private void Awake()
        {
            if(_hideOnStart)
                Hide();
        }

        public void Show()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void Hide()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;   
        }
    }
}