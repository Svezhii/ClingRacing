using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CellShopButton : MonoBehaviour
{
    [SerializeField] private PauseMenu _mainMenu;
    [SerializeField] private int _value;

    private bool isBuyed = false;
    private bool isSelected = false;
    private Button _button;
    private Wallet _wallet;

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
        if (isBuyed == false)
        {
            _mainMenu.gameObject.SetActive(true);
        }

        if (isSelected == false && isBuyed)
        {

        }
    }

    public void Init(Wallet wallet)
    {
        _wallet = wallet;
    }
}