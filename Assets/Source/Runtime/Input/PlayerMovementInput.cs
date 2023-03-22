using UnityEngine;

namespace FPS.Input
{
    public sealed class PlayerMovementInput : IPlayerMovementInput
    {
        public bool IsMoving => GetMovementInput() != Vector3.zero;
        public bool IsRotating => GetRotationInput() != Vector3.zero;
        public bool IsJumping => _inputSettings.Player.Jump.IsPressed();

        private readonly DefaultControlSettings _inputSettings;

        public PlayerMovementInput(DefaultControlSettings inputSettings)
        {
            _inputSettings = inputSettings;
        }

        public Vector3 GetMovementInput()
        {
            Vector2 moveValue = _inputSettings.Player.Move.ReadValue<Vector2>();

            return new(moveValue.x, 0, moveValue.y);
        }

        public Vector3 GetRotationInput()
        {
            Vector2 mouseDeltaValue = _inputSettings.Player.Rotate.ReadValue<Vector2>();

            return new(-mouseDeltaValue.y, mouseDeltaValue.x);
        }
    }
}