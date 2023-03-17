using UnityEngine;

namespace FPS.Model
{
    public interface IBulletView
    {
        void Miss();
        void Hit(Vector3 target, Vector3 normal);
        void Kill();
        void Damage();
    }
}