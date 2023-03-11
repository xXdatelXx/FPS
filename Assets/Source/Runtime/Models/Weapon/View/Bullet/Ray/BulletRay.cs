using System;
using Cysharp.Threading.Tasks;
using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletRay : IBulletRay
    {
        private readonly ITimer _timer;
        private readonly IGameObjectWithMovement _gameObject;
        private readonly Vector3 _standardMotion;

        public BulletRay(ITimer timer, IGameObjectWithMovement gameObject, Vector3 standardMotion)
        {
            _timer = timer.ThrowExceptionIfArgumentNull(nameof(timer));
            _gameObject = gameObject.ThrowExceptionIfArgumentNull(nameof(gameObject));
            _standardMotion = standardMotion.ThrowExceptionIfArgumentNull(nameof(standardMotion));
        }

        public void Cast() =>
            Cast(_gameObject.Position + _standardMotion);

        public void Cast(Vector3 target)
        {
            if (_timer.Playing)
                throw new InvalidOperationException(nameof(Cast));

            _gameObject.MoveTo(target);
            _timer.Play();
        }

        public async UniTask End() => await _timer.End();
    }
}