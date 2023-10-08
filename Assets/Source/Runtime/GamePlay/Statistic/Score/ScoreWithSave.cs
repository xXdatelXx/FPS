using FPS.Toolkit;
using FPS.Toolkit.Storage;

namespace FPS.GamePlay
{
    public sealed class ScoreWithSave : IScore 
    {
        private readonly IScore _score;
        private readonly IStorage<int> _storage;
        private int _maxScore;
        
        public ScoreWithSave(IScore score, string storageName) : this(score, new BinaryStorage<int>(storageName))
        { }

        public ScoreWithSave(IScore score, IStorage<int> storage)
        {
            _score = score.ThrowExceptionIfArgumentNull(nameof(score));
            _storage = storage.ThrowExceptionIfArgumentNull(nameof(storage));
            
            _maxScore = _storage.LoadOrDefault();
        }

        public int Value => _score.Value;
        
        public void Increase(int value)
        {
            _score.Increase(value);

            if (_maxScore < _score.Value)
            {
                _storage.Save(_score.Value);
                _maxScore = _score.Value;
            }
        }
    }
}