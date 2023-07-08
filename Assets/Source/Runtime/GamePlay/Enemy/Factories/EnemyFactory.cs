using System;
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
        private readonly Vector2 _bound;

        public EnemyFactory(Enemy prefab, ICharacter character, Range positionRange, Vector2 bound)
        {
            _prefab = prefab.ThrowExceptionIfArgumentNull(nameof(prefab));
            _character = character.ThrowExceptionIfArgumentNull(nameof(character));

            if (bound.x < positionRange.Max || bound.y < positionRange.Max)
                throw new ArgumentOutOfRangeException(nameof(positionRange));

            var axisRandom = new RandomNegative<float>
            (
                new RationalRandom(positionRange),
                new FiftyFiftyChance()
            );

            _positionRandom = new VectorRandom(axisRandom, axisRandom);
            _bound = bound;
        }

        public Enemy Create()
        {
            var enemy = Object.Instantiate(_prefab, NextPosition(), Quaternion.identity);
            enemy.Construct(_health, _character);

            return enemy;
        }

        private Vector2 NextPosition()
        {
            Vector2 characterPosition = _character.Movement.Position.Value;
            var position = _positionRandom.Next() + characterPosition;
            if (position.x > _bound.x)
                position.x *= -1;
            if (position.y > _bound.y)
                position.y *= -1;

            return position;
        }
    }
}