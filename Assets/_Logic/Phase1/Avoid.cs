using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

public class Avoid : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float turnSpeed = 90f;

    [Header("Detection")]
    //[SerializeField] private List<Transform> rayOrigins;
    [SerializeField] private int rayCount = 6;
    [SerializeField] private float rayAngle = 90f;
    [SerializeField] private float baseRayDis = 5f;
    [SerializeField] private LayerMask avoidMask;

    private float currentRayDis;

    private Color rayColour;

    private RaycastHit hitData;

    private bool hitSomething;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        float speedFactor = rb.linearVelocity.magnitude;
        currentRayDis = baseRayDis + speedFactor * 0.5f;
    }

    private void FixedUpdate()
    {
        HandleDetection();
        HandleAvoidance();
    }

    private void OnDrawGizmos()
    {
        /*foreach (Transform origin in rayOrigins)
        {
            if(hitSomething)
            {
                Gizmos.color = rayColour;
                Gizmos.DrawRay(origin.position, origin.forward * currentRayDis);
            }
            else
            {
                Gizmos.color = rayColour;
                Gizmos.DrawRay(origin.position, origin.forward * currentRayDis);
            }
        } */

        float halfArc = rayAngle * 0.5f;
        float step = rayAngle / (rayCount - 1);

        for (int i = 0; i < rayCount; i++)
        {
            float angle = -halfArc + step * i;
            Vector3 dir = Quaternion.AngleAxis(angle, transform.up) * transform.forward;

            Gizmos.color = rayColour;
            Gizmos.DrawRay(transform.position, dir * currentRayDis);
        }
    }

    private void HandleDetection()
    {
        hitSomething = false;

        /*foreach(Transform origin in rayOrigins)
         {
             if(Physics.Raycast(origin.position, origin.forward, out RaycastHit hit, currentRayDis, avoidMask)) //TODO: Figure out how to get each ray to be coloured independently.
             {
                 hitSomething = true;
                 hitData = hit;
                 rayColour = Color.red;
                 return;
             }
             else
             {
                 rayColour = Color.green;
             }
         } */

        rayColour = Color.green;

        float arc = rayAngle * 0.5f;
        float step = rayAngle / (rayCount - 1f);

        for (int i = 0; i < rayCount; i++)
        {
            float angle = -arc + step * i;
            Vector3 dir = Quaternion.AngleAxis(angle, transform.up) * transform.forward;

            if (Physics.Raycast(transform.position, dir, out RaycastHit hit, currentRayDis, avoidMask))
            {
                hitSomething = true;
                hitData = hit;
                rayColour = Color.red;
                break;
            }
        }
    }

    private void HandleAvoidance()
    {
        /*float turnModifier = 1f - (turnAmount / hitData.distance);

        if(rb != null && hitSomething)
        {
            float angle = transform.rotation.y;
            float finalAngle = 0f;
            if(angle < 0f)
            {
                finalAngle = 1;
            }

            if(angle > 0f)
            {
                finalAngle = -1f;
            }

            rb.AddTorque(Vector3.up * turnModifier * finalAngle, ForceMode.Acceleration);
        } */

        if(currentRayDis <= 0f)
        {
            return;
        }

        float disFactor = Mathf.Clamp01(1f - (hitData.distance / currentRayDis));

        Vector3 cross = Vector3.Cross(transform.forward, hitData.normal);
        float turnDir = Mathf.Sign(cross.y);

        if(turnDir == 0f)
        {
            return;
        }

        rb.AddRelativeTorque(0f, turnDir * (turnSpeed * disFactor), 0f, ForceMode.Acceleration);
    }
}
