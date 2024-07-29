using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class WalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Wallet _wallet;

    public void Init(Wallet wallet)
    {
        _wallet = wallet;

        _wallet.OnChangeValue += OnChangeValue;

        OnChangeValue(_wallet.Value);
    }

    private void OnDestroy()
    {
        _wallet.OnChangeValue -= OnChangeValue;
    }

    private void OnChangeValue(int value)
    {
        _text.text = value.ToString();
    }
}
