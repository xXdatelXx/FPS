using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Source.Runtime.Input;
using Source.Runtime.Models.Player.Weapon;
using Source.Runtime.Models.Player.Weapon.Interfaces;
using UnityEngine;

namespace Source.Runtime.Models.Factory.Character.Weapon
{
    public sealed class PlayerWeaponCollectionFactory : SerializedMonoBehaviour, IPlayerWeaponCollectionFactory
    {
        [SerializeField] private List<IPlayerWeaponFactory> _factories;

        public IPlayerWeapons Create() =>
            new PlayerWeapons(CreateWeaponCollection(), new PlayerWeaponInput());

        private IWeaponCollection CreateWeaponCollection()
        {
            var weapons = _factories.Select(i => i.Create()).ToList();
            return new WeaponCollection(weapons);
        }
    }
}