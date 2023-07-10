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
        private readonly float _healthPoints;
        private readonly IRandom<Vector2> _positionRandom;
        private readonly Transform _parent;

        public EnemyFactory(Enemy prefab, float enemyHealth, ICharacter character, Range positionRange, Transform parent = null)
        {
            _prefab = prefab.ThrowExceptionIfArgumentNull(nameof(prefab));
            _character = character.ThrowExceptionIfArgumentNull(nameof(character));
            _healthPoints = enemyHealth.ThrowExceptionIfValueSubOrEqualZero(nameof(enemyHealth));
            _parent = parent;
            
            _positionRandom = new CirclePointRandom(positionRange.Max, positionRange.Min);
        }

        public Enemy Create()
        {
            var enemy = Object.Instantiate(_prefab, NextPosition(), Quaternion.identity, _parent);
            enemy.Construct(new Health(_healthPoints), _character);

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