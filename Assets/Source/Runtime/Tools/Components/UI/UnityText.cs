using UnityEngine.UI;

namespace FPS.Tools
{
    public sealed class UnityText : Text, IText
    {
        public void Visualize(string value) => text = value;
    }
}