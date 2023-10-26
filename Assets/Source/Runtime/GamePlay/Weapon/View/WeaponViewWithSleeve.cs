using Cysharp.Threading.Tasks;
using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class WeaponViewWithSleeve : IWeaponView
    {
        private readonly IPool<IBulletSleeve> _pool;
        private readonly IFactory<ITimer> _timerFactory;
        private readonly IWeaponView _view;

        public WeaponViewWithSleeve(IWeaponView view, IPool<IBulletSleeve> pool, IFactory<ITimer> timerFactory)
        {
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
            _pool = pool.ThrowExceptionIfArgumentNull(nameof(pool));
            _timerFactory = timerFactory.ThrowExceptionIfArgumentNull(nameof(timerFactory));
        }

        public void Shoot()
        {
            ThrowSleeve();
            _view.Shoot();
        }

        public void Reload() => _view.Reload();

        public void Equip() => _view.Equip();

        public void UneQuip() => _view.UneQuip();

        private void ThrowSleeve()
        {
            var sleeve = _pool.Get();
            sleeve.Throw();

            ReturnSleeve(sleeve).Forget();
        }

        private async UniTaskVoid ReturnSleeve(IBulletSleeve sleeve)
        {
            var timer = _timerFactory.Create();
            timer.Play();

            await timer.End();

            sleeve.Hide();
            _pool.Return(sleeve);
        }
    }
}