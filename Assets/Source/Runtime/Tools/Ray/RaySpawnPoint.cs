using UnityEngine;

namespace Source.Runtime.Models.Weapons.Bullet.Factory
{
    public class RaySpawnPoint : MonoBehaviour, IRaySpawnPoint
    {
        public Vector3 Position => transform.position;
        public Vector3 Forward => transform.forward;
    }
}