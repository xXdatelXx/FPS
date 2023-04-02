using FPS.Tools;
using UnityEngine;

namespace FPS.Model
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
            var euler = _head.Value;
            var clampedX = _math.ClampEuler(euler.x, _xRange.Min, _xRange.Max);
            var motion = new Vector3(clampedX - _head.Value.x, 0);

            _head.Rotate(motion);
        }
    }
}