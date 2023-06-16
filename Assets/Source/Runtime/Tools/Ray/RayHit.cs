using System;
using UnityEngine;

namespace FPS.Tools
{
    public readonly struct RayHit<TTarget>
    {
        private readonly TTarget _target;
        
        public RayHit(TTarget target, Vector3 start, Vector3 end)
        {
            _target = target;
            Points = (start, end);
        }
        
        public bool Occurred => _target is not null;

        public (Vector3 Start, Vector3 End) Points { get; }

        public TTarget Target => _target ?? throw new NotImplementedException($"There isn't hit target!");
    }
}