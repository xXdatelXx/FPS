namespace FPS.Toolkit
{
    public sealed class GameObjectActivationButton : IButton
    {
        private readonly IGameObject _gameObject;

        public GameObjectActivationButton(IGameObject gameObject) =>
            _gameObject = gameObject.ThrowExceptionIfArgumentNull(nameof(gameObject));

        public void Press()
        {
            if (_gameObject.Active)
                _gameObject.Disable();
            else
                _gameObject.Enable();
        }
    }
}