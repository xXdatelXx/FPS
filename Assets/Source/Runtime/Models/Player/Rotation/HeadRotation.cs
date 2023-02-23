using Source.Runtime.Tools.Extensions;
using Source.Runtime.Tools.Math;
using Source.Runtime.Views.GameObject;
using UnityEngine;

namespace Source.Runtime.Models.Player.Rotation
{
    public sealed class HeadRotation : IHeadRotation
    {
        private readonly IGameObjectWithRotation _head;
        private readonly Mathf _math = new();
        private readonly Range _xRange;

        public HeadRotation(IGameObjectWithRotation head, Range xRange)
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
            var euler = _head.Rotation;
            var clampedX = _math.ClampEuler(euler.x, _xRange.Min, _xRange.Max);
            var motion = new Vector3(clampedX - _head.Rotation.x, 0);

            _head.Rotate(motion);
        }
    }
}