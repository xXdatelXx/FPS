using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FPS.Tools;

namespace FPS.Model
{
    public sealed class WeaponCollection : IWeaponCollection
    {
        private readonly List<IPlayerWithWeapon> _weapons;
        private int _id;

        public WeaponCollection(params IPlayerWithWeapon[] weapons) : this(weapons.ToList())
        {
        }

        public WeaponCollection(List<IPlayerWithWeapon> weapons)
        {
            _weapons = weapons.ThrowExceptionIfArgumentNull(nameof(weapons));
            if (weapons.Distinct().Count() != weapons.Count)
                throw new InvalidDataException("weapons set has same elements");
        }

        public IPlayerWithWeapon Weapon => _weapons[_id];
        public bool CanSwitch => _weapons.Count > 1;

        public void Add(IPlayerWithWeapon weapon) =>
            _weapons.Add(weapon.ThrowExceptionIfArgumentNull(nameof(weapon)));

        public void Remove(IPlayerWithWeapon weapon) =>
            _weapons.Remove(weapon);

        public IPlayerWithWeapon SwitchNext()
        {
            if (!CanSwitch)
                throw new InvalidOperationException(nameof(SwitchNext));

            _id = _id + 1 < _weapons.Count ? _id + 1 : 0;
            return _weapons[_id];
        }

        public IPlayerWithWeapon SwitchPrevious()
        {
            if (!CanSwitch)
                throw new InvalidOperationException(nameof(SwitchNext));

            _id = _id - 1 >= 0 ? _id - 1 : _weapons.Count - 1;
            return _weapons[_id];
        }
    }
}