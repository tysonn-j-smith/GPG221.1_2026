using UnityEngine;

public class Avoid : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float turnSpeed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(rb != null)
        {
            rb.AddRelativeTorque(0f, turnSpeed, 0f);
        }
    }
}
