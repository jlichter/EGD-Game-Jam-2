using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingControl : MonoBehaviour
{

    // target angle and original for rotationg platform 1 
    Quaternion targetAngle1_90 = Quaternion.Euler(90, 0, 0);
    Quaternion targetAngle1_0 = Quaternion.Euler(0, 0, 0);
    public Quaternion currentAngle1;
    // to grab the coroutine for rotation
   // IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
