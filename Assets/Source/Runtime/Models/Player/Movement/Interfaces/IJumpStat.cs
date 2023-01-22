using UnityEngine;

namespace FPS.Model
{
    public interface IJumpStat
    {
        public Vector3 Motion { get; }
        public float Time { get; }
        public AnimationCurve Coefficient { get; }
    }
}