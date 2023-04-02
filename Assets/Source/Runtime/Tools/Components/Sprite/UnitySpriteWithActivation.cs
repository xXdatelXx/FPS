using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class UnitySpriteWithActivation : ISprite
    {
        private readonly ISprite _enable;
        private readonly ISprite _disable;

        public UnitySpriteWithActivation(IUnitySpriteRenderer spriteRenderer, Sprite enable, Sprite disable)
        {
            _enable = new UnitySprite(spriteRenderer, enable);
            _disable = new UnitySprite(spriteRenderer, disable);
        }

        public void Render() => _enable.Render();
        public void Hide() => _disable.Render();
    }
}