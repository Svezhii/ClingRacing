using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAdder : MonoBehaviour
{
    private Wallet _wallet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _wallet.AddValue(coin.Value);
            coin.gameObject.SetActive(false);
        }
    }

    public void Init(Wallet wallet)
    {
        _wallet = wallet;
    }
}
