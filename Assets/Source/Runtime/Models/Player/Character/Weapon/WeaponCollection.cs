using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FPS.Tools;

namespace FPS.Model
{
    public sealed class WeaponCollection : IWeaponCollection
    {
        private readonly IReadOnlyList<IPlayerWithWeapon> _weapons;
        private readonly IWeaponCollectionView _view;
        private int _id;

        #region Constructors
        
        public WeaponCollection(params IPlayerWithWeapon[] weapons) : this(weapons.ToList(), new NullWeaponCollectionView())
        { }
        
        public WeaponCollection(IWeaponCollectionView view, params IPlayerWithWeapon[] weapons) : this(weapons.ToList(), view)
        { }

        public WeaponCollection(List<IPlayerWithWeapon> weapons) : this(weapons, new NullWeaponCollectionView())
        { }
            
        public WeaponCollection(List<IPlayerWithWeapon> weapons, IWeaponCollectionView view)
        {
            _weapons = weapons.ThrowExceptionIfArgumentNull(nameof(weapons));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
            if (weapons.Distinct().Count() != weapons.Count)
                throw new InvalidDataException("weapons set has same elements");
        }

        #endregion
        
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
            _view.Visualize(_id);
            return _weapons[_id];
        }
    }
}