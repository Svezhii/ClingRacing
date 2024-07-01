using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayButton : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    void Start()
    {
        if (_button != null)
        {
            _button.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        Time.timeScale = 1f;
        _mainMenu.gameObject.SetActive(false);
    }

}
