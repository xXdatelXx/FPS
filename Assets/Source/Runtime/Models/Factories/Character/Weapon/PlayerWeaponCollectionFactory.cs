using System;
using System.Collections.Generic;
using System.Linq;
using FPS.Input;
using FPS.Model;
using FPS.Tools;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace FPS.Factories
{
    public sealed class PlayerWeaponCollectionFactory : SerializedMonoBehaviour, IPlayerWeaponCollectionFactory
    {
        [SerializeField] private IPlayerWeaponFactory[] _factories;
        [SerializeField, Header("1 - enable, 2 - disable")]
        private List<(Sprite enable, Sprite disable, Image renderer)> _viewSprites;

        private void Awake()
        {
            if (_viewSprites.Count != _factories.Length)
                throw new InvalidOperationException("_viewSprites.Length != _factories.Length");
        }

        public IPlayerWithWeapons Create() =>
            new PlayerWithWeapons(CreateWeaponCollection(), new PlayerWeaponInput());

        private IWeaponCollection CreateWeaponCollection()
        {
            var weapons = _factories.Select(i => i.Create()).ToList();

            var sprites =
                _viewSprites.Select(i =>
                    new UnitySpriteWithActivation(new UnitySpriteRenderer(i.renderer), i.enable, i.disable)).ToArray();

            return new WeaponCollection(weapons, new WeaponCollectionView(sprites));
        }
    }
}