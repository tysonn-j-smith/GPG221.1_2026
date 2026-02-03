using UnityEngine;

public class Wander : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float turnAmount = 90f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(rb != null)
        {
            float turnDir = Random.Range(-turnAmount, turnAmount);
            rb.AddTorque(0f, turnDir, 0f);
        }
    }
}
