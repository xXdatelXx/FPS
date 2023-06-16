using UnityEngine;

namespace FPS.Toolkit
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