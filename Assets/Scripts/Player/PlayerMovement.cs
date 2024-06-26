using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation = 65;
    [SerializeField] private float _searchRadius = 10;
    [SerializeField] private float _correctDistanceRotate = 12;

    private Point _pivotPoint;
    private Transform _transform;
    private bool _isGrounded;
    private bool _isClick = false;

    private PlayerInput _playerInput;

    public bool IsTurning { get; private set; } = false;

    private void Awake()
    {
        _transform = transform;

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

    private void Update()
    {
        Move();
        TurnAroundPivot();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
        {
            _isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
        {
            _isGrounded = true;
        }
    }

    private void Move()
    {
        if (_isGrounded && IsTurning == false)
        {
            _transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }

    public void OnTurnAroundPivot(InputAction.CallbackContext context)
    {
        _isClick = context.performed;

        SearchForPivotPoints();
    }

    private void TurnAroundPivot()
    {
        if (_pivotPoint == null) return;

        if (_isClick == true)
        {
            IsTurning = true;

            if (CanRotate())
            {
                _transform.RotateAround(_pivotPoint.transform.position, _pivotPoint.transform.up, Time.deltaTime * _speedRotation);
            }
            else
            {
                IsTurning = false;
            }
        }
        else
        {
            IsTurning = false;
        }
    }

    private bool CanRotate()
    {
        float distanceToPivot = Vector3.Distance(_transform.position, _pivotPoint.transform.position);

        if(distanceToPivot <= _correctDistanceRotate && _isGrounded)
        {
            return true;
        }
        return false;
    }

    private void SearchForPivotPoints()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_transform.position, _searchRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out Point point))
            {
                _pivotPoint = point;
            }
        }
    }
}
