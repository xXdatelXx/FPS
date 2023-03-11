using System.Linq;
using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class WeaponCollectionView : IWeaponCollectionView
    {
        private readonly ISpite[] _spites;
        private ISpite _enable;

        public WeaponCollectionView(Sprite[] spites, SpriteRenderer renderer) 
            : this(spites.Select(i => new UnitySpite(renderer, i)).ToArray())
        { }
        
        public WeaponCollectionView(ISpite[] spites)
        {
            _spites = spites.ThrowExceptionIfArgumentNull(nameof(spites));
            Visualize(0);
        }

        public void Visualize(int id)
        {
            _enable?.Hide();
            _enable = _spites[id];
            _enable.Render();
        }
    }
}