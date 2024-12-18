using UnityEngine;
using UnityEngine.UI;

public class ConfirmMenu : MonoBehaviour
{
    [SerializeField] private Button _buttonYes;
    [SerializeField] private Button _buttonNo;

    private int _value;
    private Wallet _wallet;
    private CellShopButton _cell;

    private void OnEnable()
    {
        _buttonYes.onClick.AddListener(OnButtonClickYes);
        _buttonNo.onClick.AddListener(OnButtonClickNo);
    }

    private void OnDisable()
    {
        _buttonYes.onClick.RemoveListener(OnButtonClickYes);
        _buttonNo.onClick.RemoveListener(OnButtonClickNo);
    }

    private void OnButtonClickYes()
    {
        _wallet.DecreaseValue(_value);
        gameObject.SetActive(false);
        _cell.BuyCar();
    }

    private void OnButtonClickNo()
    {
        gameObject.SetActive(false);
    }

    public void Init(Wallet wallet, int value, CellShopButton cell)
    {
        _wallet = wallet;
        _value = value;
        _cell = cell;
    }
}