using UnityEngine;

namespace FPS.Model.Weapons.Bullet
{
    public interface IBulletSpawnPoint
    {
        Vector3 Position { get; }
        Vector3 Forward { get; }
    }
}