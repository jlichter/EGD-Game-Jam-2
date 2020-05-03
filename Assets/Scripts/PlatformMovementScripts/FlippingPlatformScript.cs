using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippingPlatformScript : MonoBehaviour
{

    public Transform flippingPlatform;
    public float flippingSpeed;
    public float upDurationTime;
    public float flippedDurationTime;
    // target quaternion of flipping platform
    public Vector3 targetEulerAngles;
    // original quaternio of flipping platform 
    public Vector3 originalEulerAngles;

    AudioSource soundEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        flippingPlatform = this.gameObject.transform;
        soundEffect = GetComponent<AudioSource>();
        StartCoroutine("FlipToOriginal");

    }

    // Update is called once per frame
    void Update()
    {

       

    }

  
    IEnumerator FlipToTarget() {

        // Debug.Log("transforms euler: " + transform.eulerAngles + " target euler: " + targetEulerAngles);
        soundEffect.Play();
        while (Vector3.Distance(transform.eulerAngles, targetEulerAngles) > 0.1f)
        {
            
            // Debug.Log("are we here?");
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, targetEulerAngles, flippingSpeed * Time.deltaTime);
            yield return null;
        }
        soundEffect.Stop();
        yield return new WaitForSeconds(flippedDurationTime);
        StartCoroutine("FlipToOriginal");

    }
    IEnumerator FlipToOriginal() {

        soundEffect.Play();
        while (Vector3.Distance(transform.eulerAngles, originalEulerAngles) > 0.1f)
        {
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, originalEulerAngles, flippingSpeed * Time.deltaTime);
            yield return null;
        }
        soundEffect.Stop();
        yield return new WaitForSeconds(upDurationTime);
        StartCoroutine("FlipToTarget");
    }
   
    
}
