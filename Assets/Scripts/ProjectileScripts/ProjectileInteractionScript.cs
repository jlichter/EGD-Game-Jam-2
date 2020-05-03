using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInteractionScript : MonoBehaviour
{

    public KeyCode interactInput = KeyCode.Joystick1Button3;
    public bool canInteract;
    public bool inInteractionArea;

    public ProjectileReflectionEmitter projectileOne; 
    public Transform projectileTransform;


    float dPadHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Input.GetJoystickNames().Length);
        canInteract = false;
        inInteractionArea = false;
        if(projectileOne != null)
        {
           // projectileTransform = projectileOne.pTransform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactInput) && inInteractionArea && projectileOne)
        {
            canInteract = true;
            projectileOne.activated = true;
            //projectileTransform.Rotate(0, projectileRotationSpeed * Time.deltaTime)
        }
        if (canInteract)
        {
            dPadHorizontal = Input.GetAxis("DpadHorizontalPS4");
            // rotating right 
            if (dPadHorizontal == 1)
            {
                projectileOne.RotateRight();
                
            } // rotating left 
            else if(dPadHorizontal == -1)
            {
                projectileOne.RotateLeft();
                
            }
            
        }
       
    }
}
