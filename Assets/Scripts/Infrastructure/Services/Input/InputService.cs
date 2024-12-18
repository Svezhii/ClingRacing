namespace Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        private readonly PlayerInput _playerInput;

        public InputService()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();
        }
        
        public bool IsMouseClick()
        {
            return _playerInput.Player.Move.IsPressed();
        }
        
        ~InputService()
        {
            _playerInput.Disable();
        }
    }
}