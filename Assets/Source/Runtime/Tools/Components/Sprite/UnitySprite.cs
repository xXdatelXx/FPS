using UnityEngine;

namespace FPS.Tools
{
    public sealed class UnitySprite : ISprite
    {
        private readonly IUnitySpriteRenderer _renderer;
        private readonly Sprite _sprite;

        public UnitySprite(IUnitySpriteRenderer renderer, Sprite sprite)
        {
            _renderer = renderer.ThrowExceptionIfArgumentNull(nameof(renderer));
            _sprite = sprite.ThrowExceptionIfArgumentNull(nameof(sprite));
        }

        public void Render() =>
            _renderer.Render(_sprite);

        public void Hide() =>
            _renderer.Render(default);
    }
}