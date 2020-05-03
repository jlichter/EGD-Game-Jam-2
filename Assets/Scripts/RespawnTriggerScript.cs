using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTriggerScript : MonoBehaviour
{

    public Transform player1;
    public Transform player2;
    public Transform respawnPoint1;

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
            player1.transform.position = respawnPoint1.transform.position;

        }else if(other.gameObject.tag == "Player2")
        {
            player2.transform.position = respawnPoint1.transform.position;
        }


    }
}
