using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        Vector3 currentPosition = transform.position;

        Vector3 targetPosition = new Vector3(_target.position.x, currentPosition.y, _target.position.z);

        transform.position = targetPosition;
    }
}
