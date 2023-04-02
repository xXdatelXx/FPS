using UnityEngine;

namespace FPS.Tools
{
    public sealed class GameCursor : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}