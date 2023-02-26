using Source.Runtime.Models.HealthSystem;
using Source.Runtime.Models.HealthSystem.Views;
using Source.Runtime.Tools.Components.UI;
using Source.Runtime.Views.Text;
using UnityEngine;
using GameObject = Source.Runtime.Views.GameObject.GameObject;

namespace Source.Runtime.Models.Factory.Character.Healths
{
    public sealed class CharacterHealthFactory : MonoBehaviour, ICharacterHealthFactory
    {
        [SerializeField] private CharacterOrgan _head;
        [SerializeField] private CharacterOrgan _body;
        [SerializeField] private float _healthPoint;
        [SerializeField] private Player.Character _character;
        [SerializeField] private UnityText _healthText;

        public void Create()
        {
            var character = new GameObject(_character.gameObject);
            var healthView = new CharacterHealthView(new TextView(_healthText), character);
            var health = new Health(_healthPoint, healthView);

            _head.Construct(health, 2);
            _body.Construct(health, 1);
        }
    }
}