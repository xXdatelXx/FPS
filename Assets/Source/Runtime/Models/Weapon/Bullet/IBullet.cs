using UnityEngine;

namespace FPS.Model.Weapons.Bullet
{
    public interface IBullet
    {
        void Fire(Vector3 direction);
    }
}