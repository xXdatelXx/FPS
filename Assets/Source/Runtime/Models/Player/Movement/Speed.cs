using Source.Runtime.Models.Player.Movement.Interfaces;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace Source.Runtime.Models.Player.Movement
{
    public struct Speed : ISpeed
    {
        [field: SerializeField]
        [field: Range(0, 20)]
        public float Value { get; private set; }

        public Speed(float value) => Value = value.ThrowExceptionIfValueSubZero(nameof(Speed));
    }
}