using FPS.Input;
using UnityEngine;

namespace FPS.Model
{
    //TODO Composition > Aggregation (input)
    /// <summary>
    /// Makes the weapon not strictly attached to the camera
    /// </summary>
    public sealed class WeaponSway : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _amount;
        [SerializeField] private float _maxAmount;
        private IPlayerMovementInput _input;

        private void Awake() => _input = new PlayerMovementInput();

        private void Update() =>
            transform.localPosition =
                Vector3.Lerp(transform.localPosition, Rotation(), _speed * Time.smoothDeltaTime);

        private Vector2 Rotation()
        {
            var rotation = _input.Rotation();
            float Clamp(float angle) => Mathf.Clamp(angle * _amount, -_maxAmount, _maxAmount);

            return new(-Clamp(rotation.y), Clamp(rotation.x));
        }
    }
}