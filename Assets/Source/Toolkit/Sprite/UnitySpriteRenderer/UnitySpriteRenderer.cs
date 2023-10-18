using System;
using UnityEngine;
using UnityEngine.UI;

namespace FPS.Toolkit
{
    public sealed class UnitySpriteRenderer : IUnitySpriteRenderer
    {
        private readonly Action<Sprite> _render;

        public UnitySpriteRenderer(Image renderer) =>
            _render = sprite => renderer.sprite = sprite;

        public UnitySpriteRenderer(SpriteRenderer renderer) =>
            _render = sprite => renderer.sprite = sprite;

        public void Render(Sprite sprite) => _render.Invoke(sprite);
    }
}