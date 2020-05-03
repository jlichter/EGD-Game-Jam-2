using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGoalScript : MonoBehaviour
{
    public ProjectileMirrorScript[] mirrors;
    public bool allMirrorsHit;
    public int totalMirrors;
    public GameObject blockingObject;
    // Start is called before the first frame update
    void Start()
    {
        allMirrorsHit = false;
        StartCoroutine("CheckIfAllHit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CheckIfAllHit() {

        int totalMirrorsHit = 0;

        for (int i = 0; i < mirrors.Length; i++)
        {
            if (mirrors[i].hasBeenHit)
            {
                totalMirrorsHit++;
            }
        }
      //  Debug.Log("total mirrors hit " + totalMirrorsHit);
        if(totalMirrorsHit == totalMirrors)
        {
            allMirrorsHit = true;
            Unlock();
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            // Debug.Log("okay? ");
            StartCoroutine("CheckIfAllHit");
            //CheckIfAllHit();
        }


    }
    void Unlock() {

        blockingObject.SetActive(false);

    }
}
