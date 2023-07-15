using FPS.GamePlay;
using FPS.Toolkit;
using FPS.Visual;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class WeaponViewFactory : MonoBehaviour, IFactory<IWeaponView>
    {
        [SerializeField] private ProText _bulletsText;
        [SerializeField] private WeaponAnimator _animator;
        [SerializeField] private Camera _camera;

        public IWeaponView Create() =>
            new WeaponView(new BulletsView(_bulletsText), _animator, new CameraShake(_camera));
    }
}