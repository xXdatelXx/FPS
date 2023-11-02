using UnityEngine;

namespace FPS.GamePlay
{
    public interface IBulletTrace
    {
        void Cast();
        void Cast(Vector3 target);
    }
}