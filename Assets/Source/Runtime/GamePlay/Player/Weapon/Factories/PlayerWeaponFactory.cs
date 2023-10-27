using FPS.GamePlay;
using FPS.Input;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class PlayerWeaponFactory : MonoBehaviour, IPlayerWeaponFactory
    {
        [SerializeField] private WeaponWithMagazineFactory _weaponFactory;

        public IPlayerWithWeapon Create()
        {
            var input = new PlayerWeaponInput();
            var weapon = _weaponFactory.Create();

            var playerWeapon = new PlayerWithWeapon(weapon, input);
            var playerWeaponWithMagazine = new PlayerWithMagazineWeapon(playerWeapon, weapon, input);

            return playerWeaponWithMagazine;
        }
    }
}