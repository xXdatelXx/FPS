using FPS.Factories;
using FPS.GamePlay;

namespace FPS.Data
{
    public interface IFactories
    {
        ICharacterFactory Character { get; }
        IPlayerFactory Player { get; }
        IPlayerWeaponCollectionFactory PlayerWeapon { get; }
        IEnemySimulationFactory EnemySimulation { get; }
    }
}