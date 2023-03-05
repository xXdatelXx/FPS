using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FPS.Model
{
    public sealed class RandomRecoil : IRecoil
    {
        private readonly Vector2 _max;
        private readonly Vector2 _min;

        public RandomRecoil(Vector2 max, Vector2 min)
        {
            if (min.x > max.x || min.y > max.y)
                throw new ArgumentException("min < max");
            
            (_min, _max) = (min, max);
        }

        public Vector2 Next() => 
            new (Random.Range(_min.x, _max.x), Random.Range(_min.y, _max.y));
    }
}