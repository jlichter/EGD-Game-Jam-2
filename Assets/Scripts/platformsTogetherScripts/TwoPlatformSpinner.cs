using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlatformSpinner : MonoBehaviour
{
    public Transform spinner;
    public Transform spinnerBody;
    public TwoPlatformSpinner spinnerTwo;

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

        if (other.gameObject.tag == "Player") {

            spinnerTwo.spinning = true;
        }
        if (other.gameObject.tag != "platform") {
            clockwise = !clockwise;
        }

    }
    private void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Player") {
            spinnerTwo.spinning = false;
        }
    }
    public void RotateAroundSpinner() {

        if (clockwise) {

            spinner.RotateAround(spinnerTwo.spinner.position, Vector3.up, 70 * Time.deltaTime);
            spinnerBody.Rotate(0, 100 * Time.deltaTime, 0);

        } else if (!clockwise) {

            spinner.RotateAround(spinnerTwo.spinner.position, Vector3.up, -70 * Time.deltaTime);
            spinnerBody.Rotate(0, -100 * Time.deltaTime, 0);
        }

    }
}
