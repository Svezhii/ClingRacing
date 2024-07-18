using UnityEngine;
using Assets.Scripts.MovebleSystem;
using Assets.Scripts.Player;

public class GameSystem : MonoBehaviour
{
    [SerializeField] private RotateSystem _rotateSystem;
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private PivotFinder _pivotFinder;

    private Car _currentCar;

    private void Awake()
    {
        _currentCar = new Car();
        _rotateSystem.Init(_currentCar, _pivotFinder, _inputSystem.CanRotate);
    }
}