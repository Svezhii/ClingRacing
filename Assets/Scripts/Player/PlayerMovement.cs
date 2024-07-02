using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(GroundChecker), typeof(Transform), typeof(PivotFinder))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerInput _playerInput;
    private GroundChecker _groundChecker;
    private PivotFinder _pivotFinder;
    private Transform _transform;
    private bool _isClick = false;
    private float _rotationDistanceThreshold = 3;
    private float _maxRotationSpeed = 130;

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

            Vector3 directionToPivot = _pivotFinder.Point.transform.position - _transform.position;
            directionToPivot.y = 0;

            float angle = Vector3.Angle(_transform.forward, directionToPivot);

            float rotationSpeed = Mathf.Lerp(0, _maxRotationSpeed, Mathf.Clamp01(angle / _rotationDistanceThreshold));

            Quaternion targetRotation = Quaternion.LookRotation(directionToPivot);

            transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
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
