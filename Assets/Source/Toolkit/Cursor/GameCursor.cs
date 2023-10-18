using UnityEngine;

namespace FPS.Toolkit
{
    public sealed class GameCursor : IGameCursor
    {
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