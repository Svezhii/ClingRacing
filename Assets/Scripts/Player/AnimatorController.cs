using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PivotFinder _pivotFinder;

    public readonly int Right = Animator.StringToHash(nameof(Right));
    public readonly int Left = Animator.StringToHash(nameof(Left));

    private Animator _animator;

    private bool _turnRight = false;
    private bool _turnLeft = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        FindTurnDirection();
        AnimatorHundle();
    }

    private void FindTurnDirection()
    {
        if (_pivotFinder.Point == null)
            return;

        Vector3 directionToPole = _pivotFinder.Point.transform.position - _playerMover.transform.position;

        Vector3 turn = Vector3.Cross(_playerMover.transform.forward, directionToPole);

        if(turn.y > 0 && _playerMover.IsTurning)
        {
            _turnRight = true;
            _turnLeft = false;
        }
        else if(turn.y < 0 && _playerMover.IsTurning)
        {
            _turnLeft = true;
            _turnRight = false;
        }
        else
        {
            _turnLeft = false;
            _turnRight = false;
        }
    }

    private void AnimatorHundle()
    {
        _animator.SetBool(Right, _turnRight);
        _animator.SetBool(Left, _turnLeft);
    }
}
