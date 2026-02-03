using UnityEngine;

public class Wander : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float rotationAmount;

    private float noiseFactor;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        noiseFactor = Mathf.PerlinNoise1D(Time.time) * Random.Range(-rotationAmount, rotationAmount);
    }

    private void FixedUpdate()
    {
        if(rb != null)
        {
            rb.AddRelativeTorque(0f, noiseFactor, 0f);
        }
    }
}
