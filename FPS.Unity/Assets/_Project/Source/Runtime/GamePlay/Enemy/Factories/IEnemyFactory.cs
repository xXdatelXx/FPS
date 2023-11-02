using System.Numerics;

namespace FPS.GamePlay
{
    public interface IEnemyFactory
    {
        Enemy Create(Vector3 position);
    }
}