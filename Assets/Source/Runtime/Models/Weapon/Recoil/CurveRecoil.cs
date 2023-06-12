using Cysharp.Threading.Tasks;
using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class CurveRecoil : IRecoil
    {
        private readonly Curve _curve;
        private readonly float _curveStep;
        private readonly IWeaponDelay _delay;
        private float _curveProgress;

        public CurveRecoil(Curve curve, IWeaponDelay delay, IReadOnlyMagazine magazine)
        {
            _curve = curve.ThrowExceptionIfArgumentNull(nameof(curve));
            _delay = delay.ThrowExceptionIfArgumentNull(nameof(delay));
            _curve.Time.ThrowExceptionIfValueSubOrEqualZero(nameof(curve.Time));
            _curveStep = curve.Time / magazine.Bullets;
        }

        public Vector2 Next()
        {
            UpdateProgress();

            return new(_curve[_curveProgress], _curveProgress);
        }

        private async void UpdateProgress()
        {
            _curveProgress += _curveStep;

            if (await CanReset())
                _curveProgress = 0;
        }

        private async UniTask<bool> CanReset()
        {
            await _delay.End();
            await UniTask.Yield();

            return !_delay.Playing;
        }
    }
}