using UnityEngine;

namespace FPS.Model
{
    [DisallowMultipleComponent]
    public sealed class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private CharacterOrgan _head;
        [SerializeField] private CharacterOrgan _body;
        public ICharacterOrgan Head => _head;
        public ICharacterOrgan Body => _body;
    }
}