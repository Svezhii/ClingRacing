using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarsShop : MonoBehaviour
{
    [SerializeField] private ShopCell[] _cells;

    [SerializeField] private RectTransform _leftRectTransform;
    [SerializeField] private RectTransform _firstTransform;
    [SerializeField] private RectTransform _secondTransform;
    [SerializeField] private RectTransform _thirdTransform;
    [SerializeField] private RectTransform _rightTransform;

    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;

    private void Start()
    {

    }

    private void OnEnable()
    {
        _leftButton.onClick.AddListener(OnLeftButtonClick);
        _rightButton.onClick.AddListener(OnRightButtonClick);
    }

    private void OnDisable()
    {
        _leftButton.onClick.RemoveListener(OnLeftButtonClick);
        _rightButton.onClick.RemoveListener(OnRightButtonClick);
    }

    private void OnLeftButtonClick()
    {

    }

    private void OnRightButtonClick()
    {

    }

}
