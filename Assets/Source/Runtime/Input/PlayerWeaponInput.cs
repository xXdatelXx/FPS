using UnityEngine;

namespace FPS.Model
{
    // переделаю на новой input system
    public sealed class PlayerWeaponInput : IPlayerWeaponInput
    {
        public bool Shooting => Input.GetKeyDown(KeyCode.Mouse0);
        public bool Reloading => Input.GetKeyUp(KeyCode.R);
        public bool SwitchNext => Input.GetKeyUp(KeyCode.N);
        public bool SwitchPrevious => Input.GetKeyUp(KeyCode.P);
    }
}