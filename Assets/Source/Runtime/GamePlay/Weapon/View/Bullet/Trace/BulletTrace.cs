using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletTrace : IBulletTrace
    {
        private readonly IMovement _movement;
        private readonly IPosition _throwPosition;
        private readonly float _standardMotion;

        public BulletTrace(IMovement movement, IPosition throwPosition, float standardMotion)
        {
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            _throwPosition = throwPosition.ThrowExceptionIfArgumentNull(nameof(throwPosition));
            _standardMotion = standardMotion;
        }

        public void Cast() =>
            Cast(_throwPosition.Value + _throwPosition.Forward * _standardMotion);

        public void Cast(Vector3 target) => 
            _movement.Move(target - _throwPosition.Value);
    }
}