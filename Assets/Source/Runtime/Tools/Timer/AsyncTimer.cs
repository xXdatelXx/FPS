﻿using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FPS.Tools
{
    [Serializable]
    public sealed class AsyncTimer : ITimer
    {
        private TimerState _state;

        public AsyncTimer(float time) =>
            Time = time.ThrowExceptionIfValueSubZero(nameof(time));

        [field: SerializeField] public float Time { get; }
        public bool Playing => _state == TimerState.Playing;
        public bool Canceled => _state == TimerState.Canceled;

        public async void Play()
        {
            if (_state == TimerState.Playing)
                throw new InvalidOperationException(nameof(Playing));

            _state = TimerState.Playing;

            await UniTask.Delay(TimeSpan.FromSeconds(Time));

            if (!Canceled)
                _state = TimerState.End;
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