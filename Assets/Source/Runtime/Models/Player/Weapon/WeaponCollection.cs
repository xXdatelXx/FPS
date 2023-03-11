using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FPS.Tools;
using JetBrains.Annotations;

namespace FPS.Model
{
    public sealed class WeaponCollection : IWeaponCollection
    {
        private readonly IReadOnlyList<IPlayerWithWeapon> _weapons;
        [CanBeNull] private readonly IWeaponCollectionView _view;
        private int _id;

        public WeaponCollection(IWeaponCollectionView view = null, params IPlayerWithWeapon[] weapons) : this(weapons.ToList(), view)
        {
        }

        public WeaponCollection(List<IPlayerWithWeapon> weapons, IWeaponCollectionView view = null)
        {
            _weapons = weapons.ThrowExceptionIfArgumentNull(nameof(weapons));
            _view = view;
            if (weapons.Distinct().Count() != weapons.Count)
                throw new InvalidDataException("weapons set has same elements");
        }

        public IPlayerWithWeapon Weapon => _weapons[_id];
        public bool CanSwitch => _weapons.Count > 1;
        
        public IPlayerWithWeapon SwitchNext() => 
            Switch(_id + 1 < _weapons.Count ? _id + 1 : 0);

        public IPlayerWithWeapon SwitchPrevious() => 
            Switch(_id - 1 >= 0 ? _id - 1 : _weapons.Count - 1);

        private IPlayerWithWeapon Switch(int id)
        {
            if (!CanSwitch)
                throw new InvalidOperationException(nameof(Switch));

            _id = id;
            _view?.Visualize(_id);
            return _weapons[_id];
        }
    }
}