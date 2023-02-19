using UnityEngine;

namespace Source.Runtime.Input
{
    //TODO переделать на input system 2.0
    public sealed class PlayerWeaponInput : IPlayerWeaponInput
    {
        public bool Shooting => UnityEngine.Input.GetKeyDown(KeyCode.Mouse0);
        public bool Reloading => UnityEngine.Input.GetKeyUp(KeyCode.R);
        public bool SwitchNext => UnityEngine.Input.GetKeyUp(KeyCode.N);
        public bool SwitchPrevious => UnityEngine.Input.GetKeyUp(KeyCode.P);
    }
}