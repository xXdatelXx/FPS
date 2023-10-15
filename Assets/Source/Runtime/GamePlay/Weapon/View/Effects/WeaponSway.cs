using FPS.Input;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class WeaponSway : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _force;
        [SerializeField] private float _limit;
        private IPlayerMovementInput _input;

        private void Awake() => 
            _input = new PlayerMovementInput();

        private void Update() =>
            transform.localPosition =
                Vector3.Lerp(transform.localPosition, Rotation(), _speed * Time.smoothDeltaTime);

        private Vector2 Rotation()
        {
            var rotation = _input.Rotation();
            float Clamp(float angle) => Mathf.Clamp(angle * _force, -_limit, _limit);

            return new(-Clamp(rotation.y), Clamp(rotation.x));
        }
    }
}