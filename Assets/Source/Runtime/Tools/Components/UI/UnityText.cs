using UnityEngine.UI;

namespace Source.Runtime.Tools.Components.UI
{
    public sealed class UnityText : Text, IText
    {
        public void Set(string value) => text = value;
    }
}