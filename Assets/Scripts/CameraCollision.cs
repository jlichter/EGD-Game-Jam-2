using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    /* Camera Collision script for Camera
    * tutorial provided by FilmStorm: https://www.youtube.com/watch?v=LbDQHv9z-F0
    */

    public float minDistance = 1.0f; // float for min distance to zoom in 
    public float maxDistance = 4.0f; // float for max distance to zoom out 
    public float smooth = 10.0f; // float for how smooth the motion is 

    Vector3 dollyDir;
    Vector3 dollyDirAdjustment;
    public float distance;
    // call before the game starts 
    void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;

        if(Physics.Linecast (transform.parent.position, desiredCameraPos, out hit)) {
            distance = Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance);
        } else {
            distance = maxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
    }
}
