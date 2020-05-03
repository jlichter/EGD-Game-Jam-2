using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRotate : MonoBehaviour
{
    public RotatingPlatform rotatingPlatform;

    public string designatedPlayer;

    AudioSource triggerSoundEffect;
    public float fadeTime;
    float startVolume;

    // Start is called before the first frame update
    void Start()
    {
        triggerSoundEffect = GetComponent<AudioSource>();
        startVolume = triggerSoundEffect.volume;

    }

    private void OnTriggerEnter(Collider other) {


        if (other.gameObject.tag == designatedPlayer)
        {
            rotatingPlatform.rotatingToOriginal = false;
            rotatingPlatform.rotatingToTarget = true;
            rotatingPlatform.moveSpeed = rotatingPlatform.originalMoveSpeed;
            rotatingPlatform.StartCoroutine("RotateToAngle");
            StartCoroutine("PlaySoundEffect");
            
            
        }
        
    }
   
    private void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == designatedPlayer)
        {
            rotatingPlatform.rotatingToTarget = false;
            rotatingPlatform.rotatingToOriginal = true;
            rotatingPlatform.moveSpeed = rotatingPlatform.originalMoveSpeed;
            rotatingPlatform.StartCoroutine("RotateBackToAngle");
            triggerSoundEffect.Stop();
        }


    }

    IEnumerator PlaySoundEffect() {

      
        triggerSoundEffect.Play();
        while (triggerSoundEffect.volume > 0)
        {
            triggerSoundEffect.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        yield return new WaitForSeconds(2.5f);
        triggerSoundEffect.Stop();
        triggerSoundEffect.volume = startVolume;
        
       
    }

}
