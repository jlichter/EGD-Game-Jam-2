using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatformScript : MonoBehaviour
{
    public bool activated;

    public Vector3[] points;
    public int pointNumber = 0;
    Vector3 currentTarget;

    public float tolerance;
    public float speed;
    public float delayTime;

    float delayStart;

    public bool automatic;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        if (points.Length > 0)
        {
            currentTarget = points[0];

        }
        tolerance = speed * Time.deltaTime;

    }

    private void FixedUpdate() {

        if (activated)
        {
            if (transform.position != currentTarget)
            {
                MovePlatform();
            }
            else
            {
                UpdateTarget();
            }
        }
    


    }
    void MovePlatform() {

        Vector3 heading = currentTarget - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if (heading.magnitude < tolerance)
        {
            transform.position = currentTarget;
            delayStart = Time.time;
        }

    }

    void UpdateTarget() {

        if (automatic)
        {
            if (Time.time - delayStart > delayTime)
            {
                NextPlatform();
            }
        }

    }
    public void NextPlatform() {

        pointNumber++;
        if (pointNumber >= points.Length)
        {
            pointNumber = 0;
        }
        currentTarget = points[pointNumber];
    }
}
