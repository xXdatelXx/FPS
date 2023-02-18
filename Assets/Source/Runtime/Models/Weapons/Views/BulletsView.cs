using Source.Runtime.Tools.Extensions;
using Source.Runtime.Views.Text;

namespace Source.Runtime.Models.Weapon.Views
{
    public sealed class BulletsView : IBulletView
    {
        private readonly ITextView _text;

        public BulletsView(ITextView text) => _text = text.ThrowExceptionIfArgumentNull(nameof(text));

        public void Visualize(int bullets) => _text.Visualize(bullets);
    }
}