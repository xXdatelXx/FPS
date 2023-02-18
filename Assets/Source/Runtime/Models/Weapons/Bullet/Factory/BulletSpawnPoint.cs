using UnityEngine;

namespace FPS.Model.Weapons.Bullet
{
    public class BulletSpawnPoint : MonoBehaviour, IBulletSpawnPoint
    {
        public Vector3 Position => transform.position;
        public Vector3 Forward => transform.forward;
    }
}