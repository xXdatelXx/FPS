using System;
using UnityEngine;

namespace FPS.Input
{
    public class InputSystem : MonoBehaviour
    {
        private DefaultControlSettings _inputSettings;

        public IPlayerWeaponInput PlayerWeaponInput { get; private set; }
        public IPlayerMovementInput PlayerMovementInput { get; private set; }

        private void Awake()
        {
            _inputSettings = new DefaultControlSettings();

            PlayerWeaponInput = new PlayerWeaponInput(_inputSettings);
            PlayerMovementInput = new PlayerMovementInput(_inputSettings);
        }

        private void OnEnable()
        {
            _inputSettings.Enable();
        }

        private void OnDisable()
        {
            _inputSettings.Disable();
        }
    }
}