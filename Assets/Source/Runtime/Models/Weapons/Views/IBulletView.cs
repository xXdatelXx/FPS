using UnityEngine;

namespace Source.Runtime.Models.Weapons.Views
{
    public interface IBulletView
    {
        void Visualize(Vector3 hitPoint);
    }
}