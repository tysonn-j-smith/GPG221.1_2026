using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 10f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(rb != null)
        {
            rb.AddRelativeForce(0f, 0f, speed);
        }
    }
}
