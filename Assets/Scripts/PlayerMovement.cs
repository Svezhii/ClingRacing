using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation = 65;
    [SerializeField] private float _searchRadius = 10;

    private Point _pivotPoint;
    private Transform _transform;
    public bool IsTurning { get; private set; } = false;

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
                IsTurning = true;
                TurnAroundPivot();
            }
            else
            {
                IsTurning = false;
                Move();
            }
        }
        else
        {
            IsTurning = false;
            Move();
        }
    }

    private void Move()
    {
        _transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void TurnAroundPivot()
    {
        if (_pivotPoint == null) return;

        float distanceToPivot = Vector3.Distance(_transform.position, _pivotPoint.transform.position);

        if (distanceToPivot <= 12f)
        {
            _transform.RotateAround(_pivotPoint.transform.position, _pivotPoint.transform.up, Time.deltaTime * _speedRotation);
        }
        else
        {
            IsTurning = false;
            Move();
        }
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
