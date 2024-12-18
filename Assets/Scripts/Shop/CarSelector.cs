using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector
{
    private const string CarKey = "SelectedCar";

    public void SelectCar(GameObject carPrefab)
    {
        PlayerPrefs.SetString(CarKey, carPrefab.name);
        PlayerPrefs.Save();
    }
}