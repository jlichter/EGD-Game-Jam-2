using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class ProjectileReflectionEmitter : MonoBehaviour {

    public bool activated;

    public LineRenderer projectileLine;
    public Transform pTransform;

    public int maxReflectionCount = 5;
    public float maxStepDistance = 200;

    public float RotatingSpeed;
    

    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;
    public Vector3 adjustmentLeft;
    public Vector3 adjustmentRight;

    public float lengthIncrease;

    public bool hitTrigger;
    public string targetTrigger;

    AudioSource soundEffect;

    void Awake() {

        projectileLine = this.GetComponent<LineRenderer>();
        hitTrigger = false;
        activated = false;
        soundEffect = GetComponent<AudioSource>();
        
    }
    private void Update() {

        if (activated)
        {
           // soundEffect.Play();
            // shoot a ray from the origin of transform towards the direction its facing 
            ray = new Ray(transform.position, transform.forward);

            // increase the number of positions in the line renderer 
            projectileLine.positionCount = 1;
           // Debug.Log("hello?");
            // set the first vert of the line renderer to be the transform's position
            projectileLine.SetPosition(0, transform.position);

            // set the length to be the max length of the projectile (will decrement at each reflection)
            float remainingLength = maxStepDistance;
         //   Debug.Log("remaining len: " + remainingLength);
            // for the number of reflections we have remaining ... 
            for (int i = 0; i < maxReflectionCount; i++)
            {
                
                // if we hit a mirror, reflect
                if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength) && hit.transform.tag == "projectileMirror")
                {
                    
                    // increase the number of positions in our line renderer 
                    projectileLine.positionCount += 1;

                    // set the position of the next point in the line rederer (last index of position count) 
                    projectileLine.SetPosition(projectileLine.positionCount - 1, hit.point);

                    // decrement the distance based off of this reflection 
                    remainingLength -= Vector3.Distance(ray.origin, hit.point);

                    // for hitting mirrors to the left, we adjust the angle it reflects based off adjustmentLeft 
                    if (hit.transform.position.x > transform.position.x)
                    {
                        ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal - adjustmentLeft));
                    } // for hitting mirrors to the right, we adjust the angle it reflects based off adjustmentRight 
                    else if (hit.transform.position.x < transform.position.x)
                    {
                        ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal - adjustmentRight));
                    } // else, do a normal reflection based off the surface normal 
                    else
                    {
                        ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                       
                    }            
                   
                }else if(Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength) && hit.transform.tag == targetTrigger)
                {
                    // increase the number of positions in our line renderer 
                    projectileLine.positionCount += 1;

                    // set the position of the next point in the line rederer (last index of position count) 
                    projectileLine.SetPosition(projectileLine.positionCount - 1, hit.point);

                    // decrement the distance based off of this reflection 
                    remainingLength -= Vector3.Distance(ray.origin, hit.point);
                }
                else
                { // else, put the next position to be the remainder of the length into the distance 
                    projectileLine.positionCount += 1;
                    projectileLine.SetPosition(projectileLine.positionCount - 1, ray.origin + ray.direction * remainingLength);
                }
            }
        }
        
    }
    // rotates the projectile emitter right 
    public void RotateRight() {

        transform.Rotate(0, RotatingSpeed * Time.deltaTime, 0);

    }
    // rotates the projectile mirror left 
    public void RotateLeft() {

        transform.Rotate(0, -RotatingSpeed * Time.deltaTime, 0);
    }
   
}