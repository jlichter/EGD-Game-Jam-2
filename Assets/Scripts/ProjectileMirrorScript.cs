using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMirrorScript : MonoBehaviour
{
    public bool hasBeenHit;
    public LineRenderer projectileLine;
    Transform mirrorTransform;
    public int pos;
    
    // Start is called before the first frame update
    void Start()
    {
        mirrorTransform = transform;
        StartCoroutine("CheckIfHit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CheckIfHit() {

        for(; ; )
        {
            if(projectileLine.positionCount != 0)
            {
                if (Vector3.Distance(projectileLine.GetPosition(pos), mirrorTransform.position) <= 1.0f)
                {
                   // Debug.Log(mirrorTransform.position);
                    hasBeenHit = true;
                }
                else
                {
                    hasBeenHit = false;
                }
            }
           

            yield return new WaitForSeconds(1.0f);
        }



    }
}
