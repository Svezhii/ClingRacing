using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    [SerializeField] private CellShopButton[] _cellsShop;

    private Wallet _wallet;
    private CarSelector _carSelector;

    private void Awake()
    {
        _carSelector = new CarSelector();
        _wallet = new Wallet();

        _walletView.Init(_wallet);

        foreach (var cell in _cellsShop)
        {
            cell.Init(_wallet, _carSelector);
        }
    }

    private void OnEnable()
    {
        foreach (var cell in _cellsShop)
        {
            cell.OnButtonSelected += MakeSelectable;
        }
    }

    private void OnDisable()
    {
        foreach (var cell in _cellsShop)
        {
            cell.OnButtonSelected -= MakeSelectable;
        }
    }

    private void MakeSelectable()
    {
        foreach (var cell in _cellsShop)
        {
            if(cell.IsBuyed)
            {
                cell.SetInteractable();
            }
        }
    }
}
