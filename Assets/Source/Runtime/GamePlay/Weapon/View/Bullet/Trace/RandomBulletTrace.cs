using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class RandomBulletTrace : IBulletTrace
    {
        private readonly IRandom<bool> _random;
        private readonly IBulletTrace _trace;

        public RandomBulletTrace(IBulletTrace trace, IRandom<bool> random)
        {
            _trace = trace.ThrowExceptionIfArgumentNull(nameof(trace));
            _random = random.ThrowExceptionIfArgumentNull(nameof(random));
        }

        public void Cast()
        {
            if (_random.Next())
                _trace.Cast();
        }

        public void Cast(Vector3 target)
        {
            if (_random.Next())
                _trace.Cast(target);
        }
    }
}