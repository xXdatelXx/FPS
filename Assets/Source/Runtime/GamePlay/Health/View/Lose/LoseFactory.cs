using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class LoseFactory : MonoBehaviour, IFactory<ILoseView>
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _loseAnimation;
        
        public ILoseView Create() => 
            new LoseView(new UnityAnimation(_animator, _loseAnimation));
    }
}