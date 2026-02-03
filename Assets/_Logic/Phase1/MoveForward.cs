using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float minSpeed = 1000f;
    [SerializeField] private float maxSpeed = 1500f;
    private float currentSpeed;

    private Rigidbody rb;

    private void Start()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(rb != null)
        {
            rb.AddRelativeForce(0f, 0f, currentSpeed, ForceMode.Force);
        }
    }
}
