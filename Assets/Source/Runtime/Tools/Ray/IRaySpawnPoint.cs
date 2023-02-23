using UnityEngine;

namespace Source.Runtime.Models.Weapons.Bullet.Factory
{
    public interface IRaySpawnPoint
    {
        Vector3 Position { get; }
        Vector3 Forward { get; }
    }
}