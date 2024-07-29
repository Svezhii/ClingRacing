using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    [SerializeField] private CellShopButton[] _cellsShop;

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet();

        _walletView.Init(_wallet);

        foreach (var cells in _cellsShop)
        {
            cells.Init(_wallet);
        }
    }
}
