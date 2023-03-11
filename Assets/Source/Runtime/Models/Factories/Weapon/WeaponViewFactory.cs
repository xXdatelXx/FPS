using FPS.Model;
using FPS.Tools;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class WeaponViewFactory : MonoBehaviour, IFactory<IWeaponView>
    {
        [SerializeField] private UnityText _bulletsText;
        [SerializeField] private Animation _shoot;
        [SerializeField] private Animation _reload;
        [SerializeField] private Animation _enable;
        [SerializeField] private Animation _disable;

        public IWeaponView Create()
        {
            var animator = new WeaponAnimator
            (
                new UnityAnimation(_shoot),
                new UnityAnimation(_reload),
                new UnityAnimation(_enable),
                new UnityAnimation(_disable)
            );

            return new WeaponView(new BulletsView(new TextView(_bulletsText)), animator);
        }
    }
}