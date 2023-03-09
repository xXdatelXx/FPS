using UnityEngine;

namespace FPS.Tools
{
    public sealed class UnitySpite : ISpite
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly Sprite _sprite;

        public UnitySpite(SpriteRenderer spriteRenderer, Sprite sprite)
        {
            _spriteRenderer = spriteRenderer.ThrowExceptionIfArgumentNull(nameof(spriteRenderer));
            _sprite = sprite.ThrowExceptionIfArgumentNull(nameof(sprite));
        }

        public void Render() => 
            _spriteRenderer.sprite = _sprite;

        public void Hide() => 
            _spriteRenderer.sprite = default;
    }
}