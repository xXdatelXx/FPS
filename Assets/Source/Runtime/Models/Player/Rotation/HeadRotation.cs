using Source.Runtime.Tools.Extensions;
using Source.Runtime.Tools.Math;
using UnityEngine;

namespace FPS.Model.Rotation
{
    public sealed class HeadRotation : IHeadRotation
    {
        private readonly Camera _head;
        private readonly Range _xRange;

        public HeadRotation(Camera head, Range xRange)
        {
            _head = head.ThrowExceptionIfArgumentNull(nameof(head));
            _xRange = xRange;
        }

        public void Rotate(float euler)
        {
            _head.transform.Rotate(new Vector3(euler, 0));
            Clamp();
        }

        private void Clamp()
        {
            var euler = _head.transform.localEulerAngles;
            var clampedX = Mathf.Clamp(euler.x > 180 ? euler.x - 360 : euler.x, _xRange.Min, _xRange.Max);

            _head.transform.localEulerAngles = new Vector3(clampedX, euler.y);
        }
    }
}