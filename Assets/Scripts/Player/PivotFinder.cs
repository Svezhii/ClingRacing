using System;
using UnityEngine;

public class PivotFinder : MonoBehaviour
{
    public Point Point { get; private set; }

    public event Action<bool> ExitPivotRadius;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Point point))
        {
            Point = point;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Point point))
        {
            Point = null;
            ExitPivotRadius?.Invoke(false);
        }
    }
}
