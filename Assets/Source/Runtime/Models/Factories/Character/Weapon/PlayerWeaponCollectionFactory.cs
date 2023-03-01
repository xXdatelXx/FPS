using System.Collections.Generic;
using System.Linq;
using FPS.Input;
using FPS.Model;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class PlayerWeaponCollectionFactory : SerializedMonoBehaviour, IPlayerWeaponCollectionFactory
    {
        [SerializeField] private List<IPlayerWeaponFactory> _factories;

        public IPlayerWithWeapons Create() =>
            new PlayerWithWeapons(CreateWeaponCollection(), new PlayerWeaponInput());

        private IWeaponCollection CreateWeaponCollection()
        {
            var weapons = _factories.Select(i => i.Create()).ToList();
            return new WeaponCollection(weapons);
        }
    }
}