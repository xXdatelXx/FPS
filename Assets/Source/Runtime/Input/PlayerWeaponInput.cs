using UnityEngine;

namespace FPS.Input
{
    public sealed class PlayerWeaponInput : IPlayerWeaponInput
    {
        private readonly DefaultControlSettings _inputSettings;

        public PlayerWeaponInput(DefaultControlSettings inputSettings)
        {
            _inputSettings = inputSettings;
        }

        public bool IsShooting => _inputSettings.Player.Shoot.IsPressed();
        public bool IsReloading => _inputSettings.Player.Reload.IsPressed();
        public bool IsSwitchNext => _inputSettings.Player.SwitchNext.IsPressed();
        public bool IsSwitchPrevious => _inputSettings.Player.SwitchPrevious.IsPressed();
    }
}