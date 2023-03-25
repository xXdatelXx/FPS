using UnityEngine;

namespace FPS.Model
{
    public interface IBulletView
    {
        void Miss();
        void Hit(Vector3 target);
        void Kill();
        void Damage();
    }
}