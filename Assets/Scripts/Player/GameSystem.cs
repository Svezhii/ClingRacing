using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts.MovebleSystem;
using Assets.Scripts.Player;

[RequireComponent(typeof(GroundChecker), typeof(Transform), typeof(PivotFinder))]
public class GameSystem : MonoBehaviour
{
    [SerializeField] private RotateSystem _rotateSystem;

    private Car _currentCar;




    [SerializeField] private float _speed;

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







        _currentCar = new Car();

        _rotateSystem.Init(_currentCar, _pivotFinder, CanRotate);
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

    public bool CanRotate()
    {
        return _isClick;
    }

    private void Move()
    {
        if (_groundChecker.IsGrounded)
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
