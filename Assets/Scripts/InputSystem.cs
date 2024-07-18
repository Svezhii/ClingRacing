using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    private PlayerInput _playerInput;
    private bool _isClick;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Move.performed += OnTurnAroundPivot;
        _playerInput.Player.Move.canceled += OnTurnAroundPivot;
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Player.Move.performed -= OnTurnAroundPivot;
        _playerInput.Player.Move.canceled -= OnTurnAroundPivot;
    }

    private void OnTurnAroundPivot(InputAction.CallbackContext context)
    {
        _isClick = context.performed;
    }

    public bool CanRotate()
    {
        return _isClick;
    }
}
