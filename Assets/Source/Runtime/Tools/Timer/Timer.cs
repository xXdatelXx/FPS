using System;
using FPS.Tools.GameLoop;
using UnityEngine;

namespace FPS.Tools
{
    [Serializable]
    public sealed class Timer : ITimer, IGameLoopObject
    {
        private TimerState _state;
        private float _accumulatedTime;

        public Timer(float time) =>
            _time = time.ThrowExceptionIfValueSubZero(nameof(time));

        [field: SerializeField] private float _time { get; }
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

            _accumulatedTime = Mathf.Min(_accumulatedTime + deltaTime, _time);

            if (_accumulatedTime.Equals(_time))
            {
                _state = TimerState.End;
                _accumulatedTime = 0;
            }
        }

        public void Cancel()
        {
            if (!Playing)
                throw new InvalidOperationException(nameof(Cancel));

            _state = TimerState.Canceled;
        }
    }
}