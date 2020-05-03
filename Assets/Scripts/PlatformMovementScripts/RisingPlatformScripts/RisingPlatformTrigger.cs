using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatformTrigger : MonoBehaviour
{
    public RisingPlatformScript risingPlatform;
    public string designatedPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == designatedPlayer)
        {
            risingPlatform.activated = true;


        }


    }
    private void OnTriggerExit(Collider other) {
        
        if(other.gameObject.tag == designatedPlayer)
        {
            risingPlatform.activated = false;
        }



    }
}
