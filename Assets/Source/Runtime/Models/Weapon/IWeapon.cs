using UnityEngine;

namespace FPS.Model.Weapons
{
    public interface IWeapon
    {
        bool CanShoot { get; }
        bool CanReload { get; }
        void Shoot(Vector3 direction);
        void Reload();
    }
}