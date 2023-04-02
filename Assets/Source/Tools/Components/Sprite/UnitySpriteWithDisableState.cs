using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class UnitySpriteWithDisableState : ISpite
    {
        private readonly ISpite _enable;
        private readonly ISpite _disable;

        public UnitySpriteWithDisableState(IUnitySpriteRenderer spriteRenderer, Sprite enable, Sprite disable)
        {
            _enable = new UnitySpite(spriteRenderer, enable);
            _disable = new UnitySpite(spriteRenderer, disable);
        }

        public void Render() => _enable.Render();
        public void Hide() => _disable.Render();
    }
}