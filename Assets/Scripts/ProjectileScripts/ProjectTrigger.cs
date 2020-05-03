using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTrigger : MonoBehaviour
{

    public ProjectileReflectionEmitter projectileEmitter;
    public ProjectileInteractionScript playerProjectileInteraction;
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

        if(other.gameObject.tag == "Player1")
        {
            playerProjectileInteraction.inInteractionArea = true;
           
        }


    }
    private void OnTriggerExit(Collider other) {
        
        if(other.gameObject.tag == "Player1")
        {

            playerProjectileInteraction.inInteractionArea = false;
            playerProjectileInteraction.canInteract = false;
            projectileEmitter.activated = false;


        }


    }
}
