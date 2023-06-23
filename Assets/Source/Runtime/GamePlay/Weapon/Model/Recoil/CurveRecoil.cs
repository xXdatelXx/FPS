using Cysharp.Threading.Tasks;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class CurveRecoil : IRecoil
    {
        private readonly Curve _curve;
        private readonly float _curveStep;
        private readonly IReadOnlyWeaponDelay _delay;
        private float _curveProgress;

        public CurveRecoil(Curve curve, IReadOnlyWeaponDelay delay, IReadOnlyMagazine magazine)
        {
            _curve = curve.ThrowExceptionIfArgumentNull(nameof(curve));
            _delay = delay.ThrowExceptionIfArgumentNull(nameof(delay));
            _curve.Time.ThrowExceptionIfValueSubOrEqualZero(nameof(curve.Time));
            _curveStep = curve.Time / magazine.Bullets;
        }

        public Vector2 Next()
        {
            UpdateProgress().Forget();
            return new(_curve[_curveProgress], _curveProgress);
        }

        private async UniTaskVoid UpdateProgress()
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