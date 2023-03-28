using FPS.Tools;

namespace FPS.Model
{
    public sealed class WeaponCollectionView : IWeaponCollectionView
    {
        private readonly ISpite[] _spites;
        private ISpite _active;

        public WeaponCollectionView(ISpite[] spites)
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