using FPS.Input;
using FPS.Model;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class PlayerWeaponFactory : MonoBehaviour, IPlayerWeaponFactory
    {
        [SerializeField] private WeaponWithMagazineFactory _weaponFactory;
        [SerializeField] private InputSystem _inputSystem;  

        public IPlayerWithWeapon Create()
        {
            var input = _inputSystem.PlayerWeaponInput;
            var weapon = _weaponFactory.Create();

            var playerWeapon = new PlayerWithWeapon(weapon, input);
            var playerWeaponWithMagazine = new PlayerWeaponWithMagazine(playerWeapon, weapon, input);

            return playerWeaponWithMagazine;
        }
    }
}