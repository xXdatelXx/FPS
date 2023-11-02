using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPS.Toolkit
{
    [Serializable]
    public sealed class AsyncTimer : ITimer
    {
        [SerializeField, MinValue(0)] private float _time;
        private CancellationTokenSource _cancellationTokenSource;

        public AsyncTimer(float time) =>
            _time = time.ThrowExceptionIfValueSubZero(nameof(time));

        public bool Playing { get; private set; }

        public void Play() =>
            PlayAsync().Forget();

        private async UniTaskVoid PlayAsync()
        {
            if (Playing)
                throw new InvalidOperationException(nameof(Play));

            _cancellationTokenSource = new CancellationTokenSource();

            Playing = true;

            await UniTask.Delay(TimeSpan.FromSeconds(_time), cancellationToken: _cancellationTokenSource.Token);

            Playing = false;
        }
        
        public void Stop()
        {
            if (!Playing)
                throw new InvalidOperationException(nameof(Stop));

            _cancellationTokenSource.Cancel();
            Playing = false;
        }
    }
}