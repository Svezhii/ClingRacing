using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineConnect : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private Mover _playerMovement;
    [SerializeField] private float _correctDistanceRotate = 9;

    private LineRenderer _lineRenderer;
    Vector3[] positions = new Vector3[2];

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        positions[0] = _startPosition.position;
        _lineRenderer.enabled = false;
    }

    private void Update()
    {
        positions[1] = _endPosition.position;
        _lineRenderer.SetPositions(positions);

        float distanceToPivot = Vector3.Distance(_startPosition.position, _endPosition.transform.position);

        if (distanceToPivot <= _correctDistanceRotate && _playerMovement.IsTurning)
        {
            _lineRenderer.enabled = true;
        }
        else
        {
            _lineRenderer.enabled = false;
        }
    }
}
