using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public List<string> acceptPlayerTags;       //this should contain Player1, Player2 or both, used for check vaild player
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision obj)
    {
        if (acceptPlayerTags.Contains(obj.gameObject.tag))
        {
            Debug.Log("collide with" + obj.gameObject.name);
        }
    }
}
