using UnityEngine;

namespace FPS.Model
{
    public sealed class JumpStat : IJumpStat
    {
        [field: SerializeField] public Vector3 Motion { get; }
        [field: SerializeField] public float Time { get; }
        [field: SerializeField] public AnimationCurve Coefficient { get; }
    }
}