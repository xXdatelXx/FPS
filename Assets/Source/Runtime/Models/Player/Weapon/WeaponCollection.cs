using System;
using System.Collections.Generic;
using System.Linq;
using FPS.Model.Weapons;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model.Weapon
{
    public sealed class WeaponCollection<TWeapon> : IWeaponCollection<TWeapon> where TWeapon : IWeapon
    {
        private readonly List<TWeapon> _weapons;
        private int _id;
        public TWeapon Weapon => _weapons[_id];
        public bool CanSwitchNext => _id + 1 > _weapons.Count;
        public bool CanSwitchPrevious => _id - 1 < 0;

        public WeaponCollection(params TWeapon[] weapons) : this(weapons.ToList())
        { }

        public WeaponCollection(List<TWeapon> weapons) => 
            _weapons = weapons.ThrowExceptionIfArgumentNull(nameof(weapons));

        public void Add(TWeapon weapon) =>
            _weapons.Add(weapon.ThrowExceptionIfArgumentNull(nameof(weapon)));

        public void Remove(TWeapon weapon) => _weapons.Remove(weapon);

        public TWeapon SwitchNext()
        {
            if (!CanSwitchNext)
                throw new InvalidOperationException(nameof(SwitchNext));
            
            return _weapons[++_id];
        }

        public TWeapon SwitchPrevious()
        {
            if (!CanSwitchPrevious)
                throw new InvalidOperationException(nameof(SwitchNext));
            
            return _weapons[--_id];
        }
    }
}