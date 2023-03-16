using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletRay : IBulletRay
    {
        private readonly IGameObjectWithMovement _gameObject;
        private readonly Vector3 _standardMotion;

        public BulletRay(IGameObjectWithMovement gameObject, Vector3 standardMotion)
        {
            _gameObject = gameObject.ThrowExceptionIfArgumentNull(nameof(gameObject));
            _standardMotion = standardMotion.ThrowExceptionIfArgumentNull(nameof(standardMotion));
        }

        public void Cast() =>
            Cast(_gameObject.Position + _standardMotion);

        public void Cast(Vector3 target)
        {
            Logger.Log();
            _gameObject.MoveTo(target);
        }
    }
}