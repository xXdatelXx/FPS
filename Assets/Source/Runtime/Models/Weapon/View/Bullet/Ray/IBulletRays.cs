using UnityEngine;

namespace FPS.Model
{
    public interface IBulletRays
    {
        void Cast();
        void Cast(Vector3 target);
    }
}