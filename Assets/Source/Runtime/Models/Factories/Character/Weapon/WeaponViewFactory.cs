﻿using FPS.Model;
using FPS.Tools;
using FPS.Views.Text;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class WeaponViewFactory : MonoBehaviour, IFactory<IWeaponView>
    {
        [SerializeField] private UnityText _bulletsText;
        [SerializeField] private WeaponAnimator _animator;
        
        public IWeaponView Create() => 
            new WeaponView(new BulletsView(new TextView(_bulletsText)), _animator);
    }
}