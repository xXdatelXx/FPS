using UnityEngine;

namespace FPS.GamePlay
{
    public interface IBulletRay
    {
        void Cast();
        void Cast(Vector3 target);
        void Hide();
    }
}