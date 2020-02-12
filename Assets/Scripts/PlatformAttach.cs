using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    // when player lands on platform, attach so player wont slide off
    private void OnTriggerStay(Collider other) {

        if (other.gameObject.tag == "Player1") {
            player1.transform.parent = transform;
        }
        if (other.gameObject.tag == "Player2") {
            Debug.Log("here");
            player2.transform.parent = transform;
        }
    }
    // when either player leaves platform, detach
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player1") {
            player1.transform.parent = null;
        }
        if (other.gameObject.tag == "Player2") {
            player2.transform.parent = null;
        }
    }
}
