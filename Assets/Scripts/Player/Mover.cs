using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(GroundChecker), typeof(PivotFinder))]
public class Mover : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private float _speed;

    private GroundChecker _groundChecker;
    private Transform _transform;
    private PivotFinder _pivotFinder;

    public bool IsTurning { get; private set; }

    private void Awake()
    {
        _transform = transform;

        _groundChecker = GetComponent<GroundChecker>();
        _pivotFinder = GetComponent<PivotFinder>();
    }

    private void Update()
    {
        Move();
        TurnAroundPivot();
    }

    private void OnEnable()
    {
        _pivotFinder.ExitPivotRadius += SetTurningStatus;
    }

    private void OnDisable()
    {
        _pivotFinder.ExitPivotRadius -= SetTurningStatus;
    }

    private void TurnAroundPivot()
    {
        if (_inputSystem.CanRotate())
        {
            if (_pivotFinder.Point == null) return;

            IsTurning = true;
        }
        else
        {
            IsTurning = false;
        }
    }

    private void SetTurningStatus(bool status)
    {
        IsTurning = status;
    }

    private void Move()
    {
        if (_groundChecker.IsGrounded)
        {
            _transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}
