using UnityEngine.UI;

namespace FPS.Tools
{
    public sealed class UnityText : Text, IText
    {
        public void Set(string value) => text = value;
    }
}