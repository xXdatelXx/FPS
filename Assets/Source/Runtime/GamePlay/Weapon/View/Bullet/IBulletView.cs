using UnityEngine;

namespace FPS.GamePlay
{
    public interface IBulletView
    {
        void Miss();
        void Hit(Vector3 target);
        void Kill();
        void Damage();
    }
}