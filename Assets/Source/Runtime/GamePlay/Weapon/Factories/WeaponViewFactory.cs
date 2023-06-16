using FPS.Model;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class WeaponViewFactory : MonoBehaviour, IFactory<IWeaponView>
    {
        [SerializeField] private ProText _bulletsText;
        [SerializeField] private WeaponAnimator _animator;

        public IWeaponView Create() =>
            new WeaponView(new BulletsView(_bulletsText), _animator);
    }
}