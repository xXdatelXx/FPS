using FPS.Toolkit;
using UnityEngine;
using Object = UnityEngine.Object;
using Range = FPS.Toolkit.Range;

namespace FPS.GamePlay
{
    public sealed class EnemyFactory : IFactory<Enemy>
    {
        private readonly Enemy _prefab;
        private readonly ICharacter _character;
        private readonly IHealth _health;
        private readonly IRandom<Vector2> _positionRandom;

        public EnemyFactory(Enemy prefab, ICharacter character, Range positionRange)
        {
            _prefab = prefab.ThrowExceptionIfArgumentNull(nameof(prefab));
            _character = character.ThrowExceptionIfArgumentNull(nameof(character));
            _health = _prefab;

            var axisRandom = new RandomNegative<float>
            (
                new RationalRandom(positionRange),
                new BoolRandom(new FiftyFiftyChance())
            );

            _positionRandom = new VectorRandom(axisRandom, axisRandom);
        }

        public Enemy Create()
        {
            var enemy = Object.Instantiate(_prefab, NextPosition(), Quaternion.identity);
            enemy.Construct(_health, _character);

            return enemy;
        }

        private Vector3 NextPosition()
        {
            var characterPosition = _character.Movement.Position.Value;

            var randomPosition = _positionRandom.Next();
            var normalizedPosition =
                new Vector3(randomPosition.x, 0f, randomPosition.y) + characterPosition;

            return normalizedPosition;
        }
    }
}