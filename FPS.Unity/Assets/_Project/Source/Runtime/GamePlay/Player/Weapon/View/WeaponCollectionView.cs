using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class WeaponCollectionView : IWeaponCollectionView
    {
        private readonly ISprite[] _spites;
        private ISprite _active;

        public WeaponCollectionView(ISprite[] spites)
        {
            _spites = spites.ThrowExceptionIfArgumentNull(nameof(spites));
            Visualize(0);
        }

        public void Visualize(int id)
        {
            _active?.Hide();
            _active = _spites[id];
            _active.Render();
        }
    }
}