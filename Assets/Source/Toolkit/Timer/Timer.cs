using System;
using FPS.Toolkit.GameLoop;
using UnityEngine;

namespace FPS.Toolkit
{
    [Serializable]
    public sealed class Timer : ITimer, IGameLoopObject
    {
        private float _accumulatedTime;

        public Timer(float time) =>
            _time = time.ThrowExceptionIfValueSubZero(nameof(time));

        [field: SerializeField] private float _time { get; }
        public bool Playing { get; private set; }

        public void Play()
        {
            if (Playing)
                throw new InvalidOperationException(nameof(Play));

            Playing = true;
        }

        public void Tick(float deltaTime)
        {
            if (!Playing)
                return;

            _accumulatedTime = Mathf.Min(_accumulatedTime + deltaTime, _time);

            if (_accumulatedTime.Equals(_time))
            {
                _accumulatedTime = 0;
                Playing = false;
            }
        }

        public void Stop()
        {
            if (!Playing)
                throw new InvalidOperationException(nameof(Stop));

            Playing = false;
        }
    }
}