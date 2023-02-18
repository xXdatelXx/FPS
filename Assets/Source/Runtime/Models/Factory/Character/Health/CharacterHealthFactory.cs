using FPS.Model;
using Source.Runtime.Model.Health;
using UnityEngine;
using Source.Runtime.Model.Health.Views;
using Source.Runtime.Views.Text;
using GameObject = Source.Runtime.Models.GameObjects.GameObject;

namespace Source.Runtime.CompositeRoot
{
    public sealed class CharacterHealthFactory : MonoBehaviour, ICharacterHealthFactory
    {
        [SerializeField] private CharacterOrgan _head;
        [SerializeField] private CharacterOrgan _body;
        [SerializeField] private float _healthPoint;
        [SerializeField] private Character _character;
        [SerializeField] private TextView _healthTextView;

        public void Create()
        {
            var character = new GameObject(_character.gameObject);
            var healthView = new CharacterHealthView(_healthTextView, character);
            var health = new Health(_healthPoint, healthView);

            _head.Construct(health, 2);
            _body.Construct(health, 1);
        }
    }
}