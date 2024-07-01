using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerUpForcer : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;

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
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }
    }
}
