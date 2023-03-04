using Cysharp.Threading.Tasks;
using FPS.Tools;

namespace FPS.Model
{
    public sealed class WeaponTrigger : IWeaponTrigger
    {
        private readonly IReadOnlyWeaponDelay _delay;

        public WeaponTrigger(IReadOnlyWeaponDelay delay) => 
            _delay = delay.ThrowExceptionIfArgumentNull(nameof(delay));

        public bool Pressed { get; private set; }
        
        public async void Press()
        {
            Pressed = true;
            
            await _delay.End();
            await UniTask.Yield();
            
            if (!_delay.Playing)
                Pressed = false;   
        }

        public async UniTask WaitUnPress()
        {
            await UniTask.WaitUntil(() => !Pressed);
            Pressed = false;
        }
    }
}