using UnityEngine;

namespace FPS.Model
{
    public interface IBulletRay
    {
        void Cast();
        void Cast(Vector3 target);
        void Hide();
    }
}