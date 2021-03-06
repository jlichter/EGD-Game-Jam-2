﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // to move the first platform back and forth, we have animation and speed 
    public GameObject movingPlatform1;
    Animator movingPlatformAnimator1;
    public float movingSpeed1 = 0.05f;

    public GameObject rotatingPlatform1;
    // target angle and original for rotationg platform 1 
    Quaternion targetAngle1_90 = Quaternion.Euler(90, 0, 0); 
    Quaternion targetAngle1_0 = Quaternion.Euler(0, 0, 0);
    public Quaternion currentAngle1;
    // to grab the coroutine for rotation
    IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        movingPlatformAnimator1 = movingPlatform1.GetComponent<Animator>();
        movingPlatformAnimator1.speed = movingSpeed1;

        currentAngle1 = targetAngle1_0;
        coroutine = RotatePlatform(rotatingPlatform1, 2.0f);
        StartCoroutine(coroutine);
    }
 

    IEnumerator RotatePlatform(GameObject platform, float duration) {

        while (true) {
            Debug.Log("got it");
            platform.transform.rotation = Quaternion.Slerp(platform.transform.rotation, currentAngle1, 1.0f);
            yield return new WaitForSeconds(duration);
            ChangeCurrentAngle();
        }

    }
    // changes the angle back and forth for rotating platform 
    void ChangeCurrentAngle() {

        if(currentAngle1.eulerAngles.x == targetAngle1_0.eulerAngles.x) {
            currentAngle1 = targetAngle1_90;
        } else {
            currentAngle1 = targetAngle1_0;
        }
    }

}
