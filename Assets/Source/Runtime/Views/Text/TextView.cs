﻿using FPS.Tools;

namespace FPS.Views.Text
{
    public sealed class TextView : ITextView
    {
        private readonly IText _text;

        public TextView(IText text) =>
            _text = text.ThrowExceptionIfArgumentNull();

        public void Visualize(object obj) => _text.Set(obj.ToString());
    }
}