using FPS.Factories;
using FPS.GamePlay;
using FPS.Toolkit;

namespace FPS.Data
{
    public sealed class Factories : IFactories
    {
        public Factories(ICharacterFactory character, IPlayerFactory player, IPlayerWeaponCollectionFactory playerWeapon, IEnemySimulationFactory enemySimulation, ILoseFactory loseFactory)
        {
            Character = character.ThrowExceptionIfArgumentNull(nameof(character));
            Player = player.ThrowExceptionIfArgumentNull(nameof(player));
            PlayerWeapon = playerWeapon.ThrowExceptionIfArgumentNull(nameof(playerWeapon));
            EnemySimulation = enemySimulation.ThrowExceptionIfArgumentNull(nameof(enemySimulation));
            LoseFactory = loseFactory.ThrowExceptionIfArgumentNull(nameof(loseFactory));
        }

        public ICharacterFactory Character { get; }
        public IPlayerFactory Player { get; }
        public IPlayerWeaponCollectionFactory PlayerWeapon { get; }
        public IEnemySimulationFactory EnemySimulation { get; }
        public ILoseFactory LoseFactory { get; }
    }
}