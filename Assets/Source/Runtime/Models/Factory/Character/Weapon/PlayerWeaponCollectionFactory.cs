using System.Collections.Generic;
using FPS.Model;
using System.Linq;
using FPS.Model.Weapon;
using FPS.Model.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Source.Runtime.CompositeRoot.Weapons
{
    public sealed class PlayerWeaponCollectionFactory : SerializedMonoBehaviour, IPlayerWeaponCollectionFactory
    {
        [SerializeField] private List<IPlayerWeaponFactory> _factories;

        public IPlayerWeapon Create() =>
            new PlayerWeapon(CreateWeaponCollection(), new PlayerWeaponInput());

        private IWeaponCollection<IHandWeapon> CreateWeaponCollection()
        {
            var weapons = _factories.Select(i => i.Create()).ToList();
            return new WeaponCollection<IHandWeapon>(weapons);
        }
    }
}