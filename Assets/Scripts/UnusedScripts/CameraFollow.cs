using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /* Camera follow script for player
     * tutorial provided by FilmStorm: https://www.youtube.com/watch?v=LbDQHv9z-F0
     */

    public float moveSpeed = 120.0f;
    public float clampAngle = 65.0f;
    public float inputSensitivity = 150.0f;

    public GameObject cameraFollow;
    Vector3 followPos;

    public GameObject cameraObj;
    public GameObject player;
    public float distanceToPlayer_X;
    public float distanceToPlayer_Y;
    public float distanceToPlayer_Z;

    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotX = 0.0f;
    private float rotY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotX = rotation.x;
        rotY = rotation.y;
        // hide the cursor so it doesn't show up (using ps4 controller)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        // rotation of the joysticks
        float inputX = Input.GetAxis("RightStickHorizontal1");
        float inputZ = Input.GetAxis("RightStickVertical1");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

    }
    void LateUpdate() {
        CameraUpdater();
    }

    void CameraUpdater() {

        // set target object to follow 
        Transform target = cameraFollow.transform;

        // move towards game object that is the target 
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        

    }
}


