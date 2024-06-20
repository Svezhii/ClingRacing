using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _searchRadius = 10;
    [SerializeField] private Vector3 _axis;

    private Point _pivotPoint;
    private Transform _transform;
    private bool _isTurning = false;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SearchForPivotPoints();

            if (_pivotPoint != null)
            {
                TurnAroundPivot();
            }
        }
        else
        {
            _transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }

    private void TurnAroundPivot()
    {
        if (_pivotPoint == null) return;

        float fromPivotToCar = transform.position.x - _pivotPoint.transform.position.x;


        _transform.RotateAround(_pivotPoint.transform.position, _pivotPoint.transform.up, Time.deltaTime * 100);
    }

    private void SearchForPivotPoints()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_transform.position, _searchRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out Point point))
            {
                _pivotPoint = point;
            }
        }
    }
}
