using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace Source.Runtime.Model.Timer
{
    [Serializable]
    public sealed class Timer : ITimer
    {
        [field: SerializeField] public float Time { get; }
        public bool Playing { get; private set; }

        public Timer(float time) =>
            Time = time.ThrowExceptionIfValueSubZero();

        public async void Play()
        {
            Playing = true;
            await UniTask.Delay(TimeSpan.FromSeconds(Time));
            Playing = false;
        }

        public async UniTask End() => 
            await UniTask.WaitUntil(() => Playing);
    }
}