using FPS.Toolkit;
using FPS.Toolkit.Storage;

namespace FPS.GamePlay
{
    public sealed class CharacterScore : ICharacterScore
    {
        private readonly IStorage<int> _storage;
        private readonly ICharacterScoreView _view;
        private readonly int _oldScore;

        public CharacterScore(IStorage<int> storage, ICharacterScoreView view)
        {
            _storage = storage.ThrowExceptionIfArgumentNull(nameof(storage));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
            _oldScore = storage.LoadOrDefault();
        }

        public int Kills { get; private set; }

        public void IncreaseKill()
        {
            Kills++;
            _view.Visualize(Kills);

            if (_oldScore < Kills)
                _storage.Save(Kills);
        }
    }
}