using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class PlayerUpForcer : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _jumpDuration = 0.5f; // Длительность прыжка

    private float _zOffset = 12;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Jumper jumper))
        {
            if (_rigidbody != null)
            {
                Vector3 targetPosition = transform.position + new Vector3(0, 0, _zOffset);

                transform.DOJump(targetPosition, _jumpForce, 1, _jumpDuration)
                    .SetEase(Ease.Linear)
                    .OnComplete(() =>
                    {
                        _rigidbody.isKinematic = false;
                    });
            }
        }
    }
}
