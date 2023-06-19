using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class NullBulletView : IBulletView
    {
        public void Miss()
        {
        }

        public void Hit(Vector3 target)
        {
        }

        public void Kill()
        {
        }

        public void Damage()
        {
        }
    }
}