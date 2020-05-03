using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    // original speed of rotating platform
    public float originalMoveSpeed;
    // current speed of rotating platform 
    public float moveSpeed;

    // target euler angles (rotation angle) of rotating platform
    public Vector3 targetEulerAngles;
    // original euler angles (rotation angle) of rotating platform 
    public Vector3 originalEulerAngles;

    // bool for if platform should be rotating to target euler angles
    public bool rotatingToTarget;
    // bool for if platform should be rotating to original euler angles
    public bool rotatingToOriginal;

    AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        // get the original move spped of rotating platform 
        originalMoveSpeed = moveSpeed;
        // get original euler angles (rotation angle) of platform 
        originalEulerAngles = transform.rotation.eulerAngles;

        soundEffect = GetComponent<AudioSource>();
    }

    public IEnumerator RotateToAngle() {

        soundEffect.Play();
        // while the rotating platform isn't at the target rotation and its supposed to be moving there, rotate 
        while(Vector3.Distance(transform.eulerAngles, targetEulerAngles) > 0.1f && rotatingToTarget)
        {
            moveSpeed += 0.05f;
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, targetEulerAngles, moveSpeed * Time.deltaTime);
            yield return null;
        }
        if(rotatingToTarget) transform.eulerAngles = targetEulerAngles;
        soundEffect.Stop();
        yield return null;
  
        
    }
    public IEnumerator RotateBackToAngle() {

        soundEffect.Play();
        // while the rotating platform isn't at the original rotation and its supposed to be moving there, rotate 
        while (Vector3.Distance(transform.eulerAngles, originalEulerAngles) > 0.1f && rotatingToOriginal)
        {
            moveSpeed += 0.05f;
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, originalEulerAngles, moveSpeed * Time.deltaTime);
            yield return null;
        }
        if(rotatingToOriginal) transform.eulerAngles = originalEulerAngles;
        soundEffect.Stop();
        yield return null;

    }
     

}
