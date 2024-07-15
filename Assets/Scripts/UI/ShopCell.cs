using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCell : MonoBehaviour
{
    public bool IsActive { get; private set; } = false;

    public void SwitchActive()
    {
        IsActive = !IsActive;
    }
}