using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpinner : MonoBehaviour
{
    public Transform spinner;
    public PlatformSpinner spinnerTwo;

    public bool spinning;
    public bool clockwise;

   
    // Start is called before the first frame update
    void Start()
    {
        spinning = false;
        clockwise = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spinning) {

            RotateAroundSpinner();

        }

    }
    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Player") {

            spinnerTwo.spinning = true;
        }
        if(other.gameObject.tag != "platform") {
            clockwise = !clockwise;
        }

    }
    private void OnTriggerExit(Collider other) {
        
        if(other.gameObject.tag == "Player") {
            spinnerTwo.spinning = false;
        }
    }

    //public void
    public void RotateAroundSpinner() {

        if (clockwise) {

            spinner.RotateAround(spinnerTwo.spinner.position, Vector3.up, 70 * Time.deltaTime);

        } else if (!clockwise) {

            spinner.RotateAround(spinnerTwo.spinner.position, Vector3.up, -70 * Time.deltaTime);

        }

    }
}
