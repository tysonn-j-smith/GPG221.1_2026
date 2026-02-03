using UnityEngine;

public class TurnTowards : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject targetObj;
    [SerializeField] private float turnSpeed = 2f;

    private Vector3 targetPos;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        targetObj = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        HandleFollow();
    }

    private void HandleFollow()
    {
        Vector3 targetDir;
        if(targetObj)
        {
            targetDir = (targetObj.transform.position - transform.position).normalized;

            float angle = Vector3.SignedAngle(transform.forward, targetDir, transform.up);

            rb.AddRelativeTorque(0f, angle, 0f);
        }
    }
}
