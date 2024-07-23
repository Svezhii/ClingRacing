using UnityEngine;
using Assets.Scripts.MovebleSystem;
using Assets.Scripts.Player;

public class GameSystem : MonoBehaviour
{
    [SerializeField] private RotateSystem _rotateSystem;
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private PivotFinder _pivotFinder;
    [SerializeField] private WalletView _walletView;
    [SerializeField] private CoinAdder _coinAdder;

    private Car _currentCar;
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet();
        _currentCar = new Car();
        _rotateSystem.Init(_currentCar, _pivotFinder, _inputSystem.CanRotate);
        _walletView.Init(_wallet);
        _coinAdder.Init(_wallet);
    }
}