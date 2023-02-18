using System.Collections.Generic;
using System.Linq;
using FPS.Model;
using FPS.Model.Weapon;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Source.Runtime.CompositeRoot.Weapons
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