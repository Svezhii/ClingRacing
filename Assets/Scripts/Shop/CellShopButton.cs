using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CellShopButton : MonoBehaviour
{
    [SerializeField] private ConfirmMenu _confirmMenu;
    [SerializeField] private TextMeshProUGUI _textButton;
    [SerializeField] private int _value;
    [SerializeField] private GameObject _carPrefab;
    [SerializeField] private bool _isDefaultCar = false;

    public bool IsBuyed { get; private set; } = false;
    public bool IsSelected { get;private set; } = false;
    private Button _button;
    private Wallet _wallet;
    private CarSelector _carSelector;

    public event Action OnButtonSelected;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        if (_wallet.Value < _value)
        {
            _button.interactable = false;
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (IsBuyed == false)
        {
            _confirmMenu.gameObject.SetActive(true);
            _confirmMenu.Init(_wallet, _value, this);
        }

        if (IsSelected == false && IsBuyed)
        {
            _carSelector.SelectCar(_carPrefab);

            OnButtonSelected?.Invoke();

            _textButton.SetText("Selected");
            IsSelected = true;
            _button.interactable = false;
        }
    }

    public void SetInteractable()
    {
        _textButton.SetText("Select");
        IsSelected = false;
        _button.interactable = true;
    }

    public void Init(Wallet wallet, CarSelector carSelector)
    {
        _wallet = wallet;
        _carSelector = carSelector;

        if (_isDefaultCar)
        {
            IsBuyed = true;
            IsSelected = true;
        }
    }

    public void BuyCar()
    {
        IsBuyed = true;
        _textButton.SetText("Select");
    }
}