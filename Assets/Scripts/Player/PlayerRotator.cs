using UnityEngine;

[RequireComponent(typeof(GameSystem))]
public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _alignmentSpeed = 2f;

    private Transform _transform;
    private readonly float[] _allowedAngles = { 0f, 90f, 180f, -90f };
    private GameSystem _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<GameSystem>();
        _transform = transform;
    }

    private void Update()
    {
        if(_playerMovement.IsTurning == false)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        float currentYRotation = _transform.eulerAngles.y;

        float nearestAngle = FindNearestAngle(currentYRotation);

        float newYRotation = Mathf.LerpAngle(currentYRotation, nearestAngle, Time.deltaTime * _alignmentSpeed);

        _transform.rotation = Quaternion.Euler(_transform.eulerAngles.x, newYRotation, _transform.eulerAngles.z);
    }

    private float FindNearestAngle(float currentAngle)
    {
        float nearestAngle = _allowedAngles[0];
        float minDifference = Mathf.Abs(Mathf.DeltaAngle(currentAngle, nearestAngle));

        foreach (float angle in _allowedAngles)
        {
            float difference = Mathf.Abs(Mathf.DeltaAngle(currentAngle, angle));

            if (difference < minDifference)
            {
                minDifference = difference;
                nearestAngle = angle;
            }
        }

        return nearestAngle;
    }
}
