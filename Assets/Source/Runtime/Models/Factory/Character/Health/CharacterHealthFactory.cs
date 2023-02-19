using Source.Runtime.Models.Health;
using Source.Runtime.Models.Health.Views;
using Source.Runtime.Views.Text;
using UnityEngine;
using GameObject = Source.Runtime.Views.GameObject.GameObject;

namespace Source.Runtime.Models.Factory.Character.Health
{
    public sealed class CharacterHealthFactory : MonoBehaviour, ICharacterHealthFactory
    {
        [SerializeField] private CharacterOrgan _head;
        [SerializeField] private CharacterOrgan _body;
        [SerializeField] private float _healthPoint;
        [SerializeField] private Player.Character _character;
        [SerializeField] private TextView _healthTextView;

        public void Create()
        {
            var character = new GameObject(_character.gameObject);
            var healthView = new CharacterHealthView(_healthTextView, character);
            var health = new Models.Health.Health(_healthPoint, healthView);

            _head.Construct(health, 2);
            _body.Construct(health, 1);
        }
    }
}