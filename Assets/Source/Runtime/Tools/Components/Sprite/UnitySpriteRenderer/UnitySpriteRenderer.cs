using System;
using UnityEngine;
using UnityEngine.UI;

namespace FPS.Tools
{
    public sealed class UnitySpriteRenderer : IUnitySpriteRenderer
    {
        private readonly Func<Sprite, object> _render;

        public UnitySpriteRenderer(Image renderer) =>
            _render = sprite => renderer.sprite = sprite;

        public UnitySpriteRenderer(SpriteRenderer renderer) =>
            _render = sprite => renderer.sprite = sprite;

        public void Render(Sprite sprite) => _render.Invoke(sprite);
    }
}