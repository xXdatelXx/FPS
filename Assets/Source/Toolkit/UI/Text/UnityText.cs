using UnityEngine.UI;

namespace FPS.Toolkit
{
    public sealed class UnityText : Text, IText
    {
        public void Visualize(string value) =>
            text = value;
    }
}