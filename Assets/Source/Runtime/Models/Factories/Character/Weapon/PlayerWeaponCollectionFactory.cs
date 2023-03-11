using System;
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
        [SerializeField] private IPlayerWeaponFactory[] _factories;
        [SerializeField] private Sprite[] _viewSprites;
        [SerializeField] private SpriteRenderer _viewSpriteRenderer;

        private void Awake()
        {
            if (_viewSprites.Length != _factories.Length)
                throw new InvalidOperationException("_viewSprites.Length != _factories.Length");
        }

        public IPlayerWithWeapons Create() =>
            new PlayerWithWeapons(CreateWeaponCollection(), new PlayerWeaponInput());

        private IWeaponCollection CreateWeaponCollection()
        {
            var weapons = _factories.Select(i => i.Create()).ToList();
            return new WeaponCollection(weapons, new WeaponCollectionView(_viewSprites, _viewSpriteRenderer));
        }
    }
}