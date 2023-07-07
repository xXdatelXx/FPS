using System;
using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class EnemyFactory : IFactory<Enemy>
    {
        private readonly Enemy _prefab;
        private readonly ICharacter _character;
        private readonly IHealth _health;

        public EnemyFactory(Enemy prefab, ICharacter character)
        {
            _prefab = prefab.ThrowExceptionIfArgumentNull(nameof(prefab));
            _character = character.ThrowExceptionIfArgumentNull(nameof(character));
        }

        public Enemy Create()
        {
            throw new NotImplementedException();
        }
    }
}