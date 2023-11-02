using UnityEngine;

namespace FPS.Input
{
    public sealed class PlayerWeaponInput : IPlayerWeaponInput
    {
        private readonly PlayerInputActionAsset.WeaponActions _inputAction;

        public PlayerWeaponInput()
        {
            _inputAction = new PlayerInputActionAsset().Weapon;
            _inputAction.Enable();
        }

        public bool Shooting => _inputAction.Shoot.IsPressed();
        public bool Reloading => _inputAction.Reload.IsPressed();
        public bool SwitchNext => SwitchDirection() > 0;
        public bool SwitchPrevious => SwitchDirection() < 0;

        private float SwitchDirection() => _inputAction.Switch.ReadValue<Vector2>().y;
    }
}