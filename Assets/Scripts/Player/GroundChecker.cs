using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsGrounded { get; private set; } = true;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
        {
            IsGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
        {
            IsGrounded = true;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.TryGetComponent(out Ground ground))
        {
            IsGrounded = true;
        }
    }
}
