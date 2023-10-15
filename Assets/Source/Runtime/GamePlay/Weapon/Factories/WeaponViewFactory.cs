using FPS.GamePlay;
using FPS.Toolkit;
using FPS.Toolkit.GameLoop;
using FPS.Visual;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class WeaponViewFactory : MonoBehaviour, IFactory<IWeaponView>
    {
        [SerializeField] private WeaponAnimator _animator;
        [SerializeField] private Camera _camera;
        [SerializeField] private BulletSleevesFactory _sleevesFactory;
        [SerializeField, MinValue(0)] private float _sleeveThrowTime;
        private readonly IGameLoopObjects _sleevesWorkTimers = new GameLoopObjects();

        private void Awake() => 
            new GameLoop(new GameTime(), _sleevesWorkTimers).Start();

        public IWeaponView Create()
        {
            var sleevePool = new Pool<IBulletSleeve>(_sleevesFactory);
            var shootCameraShake = new CameraShake(_camera);
            var weaponView = new WeaponView(_animator, shootCameraShake);
            var sleevesWorkTimersFactory = new TimerFactory(_sleeveThrowTime, _sleevesWorkTimers);
            
            return new WeaponViewWithSleeve(weaponView, sleevePool, sleevesWorkTimersFactory);
        }
    }
}