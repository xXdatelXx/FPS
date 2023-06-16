using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FPS.Toolkit.GameLoop
{
    public sealed class PhysicGameTime : IGameTime
    {
        private readonly float _timeStep;

        public PhysicGameTime(float timeStep = 0.02f) =>
            _timeStep = timeStep.ThrowExceptionIfValueSubOrEqualZero(nameof(timeStep));

        public bool Active => Time.timeScale != 0;
        public float FrameDelta => Time.fixedDeltaTime;

        public void Enable() => Time.timeScale = 1;
        public void Disable() => Time.timeScale = 0;

        public async UniTask NextFrame() => await UniTask.Delay(TimeSpan.FromSeconds(_timeStep));
    }
}