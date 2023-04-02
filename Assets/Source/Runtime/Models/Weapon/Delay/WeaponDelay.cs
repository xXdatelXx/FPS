using System;
using Cysharp.Threading.Tasks;
using FPS.Tools;

namespace FPS.Model
{
    public sealed class WeaponDelay : IWeaponDelay
    {
        private readonly ITimer _timer;

        public WeaponDelay(ITimer timer) =>
            _timer = timer.ThrowExceptionIfArgumentNull(nameof(timer));

        public bool Playing => _timer.Playing;
        public bool Canceled => _timer.Canceled;

        public void Play()
        {
            if (Playing)
                throw new InvalidOperationException(nameof(Play));

            _timer.Play();
        }

        public void Cancel() => _timer.Cancel();
    }
}