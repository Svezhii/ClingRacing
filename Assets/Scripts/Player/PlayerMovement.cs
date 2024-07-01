using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(GroundChecker), typeof(Transform), typeof(PivotFinder))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation = 65;

    private PlayerInput _playerInput;
    private GroundChecker _groundChecker;
    private PivotFinder _pivotFinder;
    private Transform _transform;
    private bool _isClick = false;

    public bool IsTurning { get; private set; }

    private void Awake()
    {
        _transform = transform;

        _playerInput = new PlayerInput();

        _groundChecker = GetComponent<GroundChecker>();
        _pivotFinder = GetComponent<PivotFinder>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Move.performed += OnTurnAroundPivot;
        _playerInput.Player.Move.canceled += OnTurnAroundPivot;
        _pivotFinder.ExitPivotRadius += SetTurningStatus;
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Player.Move.performed -= OnTurnAroundPivot;
        _playerInput.Player.Move.canceled -= OnTurnAroundPivot;
        _pivotFinder.ExitPivotRadius -= SetTurningStatus;
    }

    private void Update()
    {
        Move();
        TurnAroundPivot();
    }

    private void Move()
    {
        if (_groundChecker.IsGrounded && IsTurning == false)
        {
            _transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }

    private void TurnAroundPivot()
    {
        if (_pivotFinder.Point == null) return;

        if (_isClick == true)
        {
            IsTurning = true;

            _transform.RotateAround(_pivotFinder.Point.transform.position, _pivotFinder.Point.transform.up, Time.deltaTime * _speedRotation);
        }
        else
        {
            IsTurning = false;
        }
    }

    private void OnTurnAroundPivot(InputAction.CallbackContext context)
    {
        _isClick = context.performed;
    }

    private void SetTurningStatus(bool status)
    {
        IsTurning = status;
    }
}
