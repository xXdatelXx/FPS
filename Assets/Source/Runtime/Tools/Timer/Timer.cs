using System;
using Cysharp.Threading.Tasks;
using FPS.Tools.GameLoop;
using UnityEngine;

namespace FPS.Tools
{
    [Serializable]
    public sealed class Timer : ITimer, ITickable
    {
        private TimerState _state;
        private float _accumulatedTime;

        public Timer(float time) =>
            Time = time.ThrowExceptionIfValueSubZero(nameof(time));

        [field: SerializeField] public float Time { get; }
        public bool Playing => _state == TimerState.Playing;
        public bool Canceled => _state == TimerState.Canceled;

        public void Play()
        {
            if (Playing)
                throw new InvalidOperationException(nameof(Play));

            _state = TimerState.Playing;
        }

        public void Tick(float deltaTime)
        {
            if (!Playing)
                return;

            _accumulatedTime = Mathf.Min(_accumulatedTime + deltaTime, Time);

            if (_accumulatedTime.Equals(Time))
            {
                _state = TimerState.End;
                _accumulatedTime = 0;
            }
        }

        public async UniTask End() =>
            await UniTask.WaitUntil(() => !Playing);

        public void Cancel()
        {
            if (!Playing)
                throw new InvalidOperationException(nameof(Cancel));

            _state = TimerState.Canceled;
        }
    }
}