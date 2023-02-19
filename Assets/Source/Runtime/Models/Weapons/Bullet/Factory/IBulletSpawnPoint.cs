using UnityEngine;

namespace Source.Runtime.Models.Weapons.Bullet.Factory
{
    public interface IBulletSpawnPoint
    {
        Vector3 Position { get; }
        Vector3 Forward { get; }
    }
}