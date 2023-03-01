using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public struct Speed : ISpeed
    {
        [field: SerializeField]
        [field: Range(0, 20)]
        public float Value { get; private set; }

        public Speed(float value) => Value = value.ThrowExceptionIfValueSubZero(nameof(Speed));
    }
}