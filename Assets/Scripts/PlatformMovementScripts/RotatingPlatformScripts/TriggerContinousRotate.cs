using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerContinousRotate : MonoBehaviour
{
    public ContinousRotating continousRotater;

    public string designatedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        
        if(other.gameObject.tag == designatedPlayer)
        {
            Debug.Log("hereeee !");
            continousRotater.Rotate();


        }
    }

    private void OnTriggerExit(Collider other) {
        


    }
}
