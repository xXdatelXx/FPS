using Source.Runtime.Model.Health;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Source.Runtime.CompositeRoot
{
    public sealed class CharacterHealthFactory : SerializedMonoBehaviour, ICharacterHealthFactory
    {
        [SerializeField] private ICharacterOrgan _head;
        [SerializeField] private ICharacterOrgan _body;
        [SerializeField] private float _healthPoint;

        public void Create()
        {
            var health = new Health(_healthPoint);

            _head.Construct(health, 2);
            _body.Construct(health, 1);
        }
    }
}