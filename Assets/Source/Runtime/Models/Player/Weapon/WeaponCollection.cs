using System;
using System.Collections.Generic;
using System.Linq;
using Source.Runtime.Models.Player.Weapon.Interfaces;
using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.Models.Player.Weapon
{
    public sealed class WeaponCollection : IWeaponCollection
    {
        private readonly List<IPlayerWithWeapon> _weapons;
        private int _id;

        public WeaponCollection(params IPlayerWithWeapon[] weapons) : this(weapons.ToList())
        {
        }

        public WeaponCollection(List<IPlayerWithWeapon> weapons) =>
            _weapons = weapons.ThrowExceptionIfArgumentNull(nameof(weapons));

        public IPlayerWithWeapon Weapon => _weapons[_id];
        public bool CanSwitchNext => _id + 1 > _weapons.Count;
        public bool CanSwitchPrevious => _id - 1 < 0;

        public void Add(IPlayerWithWeapon weapon) =>
            _weapons.Add(weapon.ThrowExceptionIfArgumentNull(nameof(weapon)));

        public void Remove(IPlayerWithWeapon weapon) =>
            _weapons.Remove(weapon);

        public IPlayerWithWeapon SwitchNext()
        {
            if (!CanSwitchNext)
                throw new InvalidOperationException(nameof(SwitchNext));

            return _weapons[++_id];
        }

        public IPlayerWithWeapon SwitchPrevious()
        {
            if (!CanSwitchPrevious)
                throw new InvalidOperationException(nameof(SwitchNext));

            return _weapons[--_id];
        }
    }
}