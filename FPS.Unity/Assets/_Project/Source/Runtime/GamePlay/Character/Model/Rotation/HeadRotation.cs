using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class HeadRotation : IHeadRotation
    {
        private readonly IRotation _head;
        private readonly Mathf _math = new();
        private readonly Range _xRange;

        public HeadRotation(IRotation head, Range xRange)
        {
            _head = head.ThrowExceptionIfArgumentNull(nameof(head));
            _xRange = xRange;
        }

        public void Rotate(float euler)
        {
            _head.Rotate(new Vector3(euler, 0));
            Clamp();
        }

        private void Clamp()
        {
            var clampedX = _math.ClampEuler(_head.Euler.x, _xRange.Min, _xRange.Max);
            var motion = new Vector3(clampedX - _head.Euler.x, 0);

            _head.Rotate(motion);
        }
    }
}