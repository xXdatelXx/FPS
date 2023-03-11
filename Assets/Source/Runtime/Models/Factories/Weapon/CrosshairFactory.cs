using FPS.Model;
using FPS.Tools;
using UnityEngine;

namespace Source.Runtime.Models.Factories.Weapon
{
    public sealed class CrosshairFactory : MonoBehaviour, IFactory<ICrosshair>
    {
        [SerializeField] private Animation _hit;
        [SerializeField] private Animation _kill;
        
        public ICrosshair Create()
        {
            var animator = new CrosshairAnimator(_hit, _kill);
            return new Crosshair(animator);
        }
    }
}