using UnityEngine;

namespace FPS.Input
{
    public sealed class PlayerMovementInput : IPlayerMovementInput
    {
        private readonly PlayerInputActionAsset _inputAction;

        public PlayerMovementInput()
        {
            _inputAction = new PlayerInputActionAsset();
            _inputAction.Enable();
        }

        public bool Moving => _inputAction.Movement.Move.IsPressed();
        public bool Rotating => _inputAction.Rotation.Rotate.IsPressed();

        public Vector3 Movement()
        {
            var value = _inputAction.Movement.Move.ReadValue<Vector2>();
            return new(value.x, 0, value.y);
        }

        public Vector2 Rotation()
        {
            var value = _inputAction.Rotation.Rotate.ReadValue<Vector2>();
            return new(-value.y, value.x);
        }

        public bool Jump() => _inputAction.Movement.Jump.triggered;
    }
}