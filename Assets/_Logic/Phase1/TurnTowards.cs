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

            //NOTE: Just messing around at this point.
            float targetAngle = Vector3.Angle(transform.forward, targetDir);
            float angle = Vector3.SignedAngle(transform.forward, targetDir, transform.up);
            float torqueModifier = 1f - (targetAngle / 90f);
            float torque = angle * torqueModifier * turnSpeed;

            rb.AddRelativeTorque(0f, torque, 0f);
        }
    }
}
