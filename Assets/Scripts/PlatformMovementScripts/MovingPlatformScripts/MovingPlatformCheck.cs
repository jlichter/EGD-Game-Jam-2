using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class MovingPlatformCheck : MonoBehaviour
    {
        public Transform stickTo;
        public Camera playerCamera1;
        public Camera playerCamera2;

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            

        }

        private void OnTriggerStay(Collider other) {

            if (other.gameObject.tag == "Player1")
            {
                other.transform.parent = stickTo;
                playerCamera1.transform.parent = stickTo;
            }else if(other.gameObject.tag == "Player2")
        {
            other.transform.parent = stickTo;
            playerCamera2.transform.parent = stickTo;
        }

        }

        private void OnTriggerExit(Collider other) {

            if (other.gameObject.tag == "Player1")
            {
                other.transform.parent = null;
                playerCamera1.transform.parent = null;
            }
        else if (other.gameObject.tag == "Player2")
        {
            other.transform.parent = null;
            playerCamera2.transform.parent = null;
        }

    }
    }


