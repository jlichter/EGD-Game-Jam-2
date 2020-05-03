using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousRotating : MonoBehaviour
{
    public float rotatingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rotate() {

        transform.Rotate(0, rotatingSpeed * Time.deltaTime, 0);

    }


}
