using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseWander : SteeringBehaviour
{
    public float frequency = 0.3f;
    public float radius = 10.0f;

    public float theta = 0;
    public float amplitude = 80;
    public float distance = 5;

    public enum Axis { Horizontal, Vertical };

    public Axis axis = Axis.Horizontal;

    Vector3 target;
    Vector3 worldTarget;

    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Vector3 localCP = (Vector3.forward * distance);
        Vector3 rot = transform.rotation.eulerAngles;
        rot.x = rot.z = 0;
        Vector3 worldCP = transform.position + (Quaternion.Euler(rot) * localCP);
        Gizmos.color = Color.cyan;

        Gizmos.DrawWireSphere(worldCP, radius);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(worldTarget, 0.5f);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, worldTarget);

    }

    // Update is called once per frame
    public override Vector3 Calculate()
    {
        float n = (Mathf.PerlinNoise(theta, 1) * 2) - 1;
        float angle = n * amplitude * Mathf.Deg2Rad;

        Vector3 rot = transform.rotation.eulerAngles;
        rot.x = 0;

        if (axis == Axis.Horizontal)
        {
            target.x = Mathf.Sin(angle);
            target.z = Mathf.Cos(angle);
            target.y = 0;
            rot.z = 0;
        }
        else
        {
            target.y = Mathf.Sin(angle);
            target.z = Mathf.Cos(angle);
        }
        target *= radius;
        Vector3 localTarget = target + (Vector3.forward * distance); // projecting forward in local space
        worldTarget = transform.position + Quaternion.Euler(rot) * localTarget;

        theta += frequency * Time.deltaTime * Mathf.PI * 2.0f;

        return boid.SeekForce(worldTarget);


    }
}
