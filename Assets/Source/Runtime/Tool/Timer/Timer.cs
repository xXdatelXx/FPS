using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FPS.Tools
{
    [Serializable]
    public sealed class Timer : ITimer
    {
        private bool _canceled;

        public Timer(float time) =>
            Time = time.ThrowExceptionIfValueSubZero();

        [field: SerializeField] public float Time { get; }
        public bool Playing { get; private set; }

        public async void Play()
        {
            Playing = true;
            await UniTask.Delay(TimeSpan.FromSeconds(Time));

            if (!_canceled)
                Playing = false;

            _canceled = false;
        }

        public async UniTask End() =>
            await UniTask.WaitUntil(() => Playing);

        public void Cancel()
        {
            if (!Playing)
                throw new InvalidOperationException(nameof(Cancel));

            _canceled = true;
        }
    }
}