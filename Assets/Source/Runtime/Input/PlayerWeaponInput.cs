using UnityEngine;

namespace FPS.Input
{
    public sealed class PlayerWeaponInput : IPlayerWeaponInput
    {
        private readonly PlayerInputActionAsset _inputAction;

        public PlayerWeaponInput()
        {
            _inputAction = new PlayerInputActionAsset();
            _inputAction.Enable();
        }

        public bool Shooting => _inputAction.Weapon.Shoot.IsPressed();
        public bool Reloading => _inputAction.Weapon.Reload.IsPressed();
        public bool SwitchNext => _inputAction.Weapon.Switch.ReadValue<Vector2>().y > 0;
        public bool SwitchPrevious => _inputAction.Weapon.Switch.ReadValue<Vector2>().y < 0;
    }
}