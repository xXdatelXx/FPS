using System;
using System.Collections.Generic;
using System.Linq;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model.Weapon
{
    public sealed class WeaponCollection : IWeaponCollection
    {
        private readonly List<IPlayerWeapon> _weapons;
        private int _id;

        public WeaponCollection(params IPlayerWeapon[] weapons) : this(weapons.ToList())
        { }

        public WeaponCollection(List<IPlayerWeapon> weapons) => 
            _weapons = weapons.ThrowExceptionIfArgumentNull(nameof(weapons));

        public IPlayerWeapon Weapon => _weapons[_id];
        public bool CanSwitchNext => _id + 1 > _weapons.Count;
        public bool CanSwitchPrevious => _id - 1 < 0;

        public void Add(IPlayerWeapon weapon) => 
            _weapons.Add(weapon.ThrowExceptionIfArgumentNull(nameof(weapon)));

        public void Remove(IPlayerWeapon weapon) => 
            _weapons.Remove(weapon);

        public IPlayerWeapon SwitchNext()
        {
            if (!CanSwitchNext)
                throw new InvalidOperationException(nameof(SwitchNext));

            return _weapons[++_id];
        }

        public IPlayerWeapon SwitchPrevious()
        {
            if (!CanSwitchPrevious)
                throw new InvalidOperationException(nameof(SwitchNext));

            return _weapons[--_id];
        }
    }
}