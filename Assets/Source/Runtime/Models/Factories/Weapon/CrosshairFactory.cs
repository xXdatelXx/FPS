using FPS.Model;
using FPS.Tools;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class CrosshairFactory : MonoBehaviour, IFactory<ICrosshair>
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _hitAnimation;
        [SerializeField] private string _killAnimation;

        public ICrosshair Create()
        {
            var animator = new CrosshairAnimator(_animator, _hitAnimation, _killAnimation);
            return new Crosshair(animator);
        }
    }
}