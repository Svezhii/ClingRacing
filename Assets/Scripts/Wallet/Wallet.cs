using System;
using UnityEngine;

public class Wallet
{
    private const string WalletKey = "WalletValue";

    public int Value { get; private set; }
    public event Action<int> OnChangeValue;

    public Wallet()
    {
        Value = PlayerPrefs.GetInt(WalletKey, 100);
        OnChangeValue?.Invoke(Value);
    }

    public void AddValue(int value)
    {
        Value += value;

        PlayerPrefs.SetInt(WalletKey, Value);
        PlayerPrefs.Save();

        OnChangeValue?.Invoke(Value);
    }

    public void DecreaseValue(int value)
    {
        Value -= value;

        PlayerPrefs.SetInt(WalletKey, Value);
        PlayerPrefs.Save();

        OnChangeValue?.Invoke(Value);
    }
}
