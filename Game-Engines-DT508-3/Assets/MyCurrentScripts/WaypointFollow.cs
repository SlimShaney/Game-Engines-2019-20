using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    public float Mass;
    public float MaxVelocity;
    public float MaxForce;

    private Vector3 velocity;
    public Transform currentTarget;

    public GameObject[] waypoints;
    public int i = 0;

    private void Start()
    {
        velocity = Vector3.zero;
        currentTarget = waypoints[i].transform;
    }

    private void Update()
    {
        if (Vector3.Distance(this.transform.position, currentTarget.transform.position) <= 2)
        {
            i++;
            if (i >= waypoints.Length)
            {
                i = 0;
            }
            currentTarget = waypoints[i].transform;
        }
        
        var desiredVelocity = currentTarget.transform.position - transform.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;

        Debug.DrawRay(transform.position, velocity.normalized * 2, Color.green);
        Debug.DrawRay(transform.position, desiredVelocity.normalized * 2, Color.magenta);

    }
}
