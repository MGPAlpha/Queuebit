﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // if (isLocalPlayer) {
        //     Debug.Log("localplayer true");
        // } else {
        //     Debug.Log("localplayer false");
        // }
        // if (hasAuthority) {
        //     Debug.Log("HA true");
        // } else {
        //     Debug.Log("HA false");
        // }
    }

    // Update is called once per frame
    private bool isCameraConnected = false;
    void Update()
    {
        //Note: Update() here runs on all playerunits.
        if (hasAuthority == false) { //Do you have authority over this object?
            return;
        }
        
        if (!isCameraConnected) {
            Camera.main.GetComponent<PlayerCameraController>().setCameraTarget(this.transform);
            isCameraConnected = true;
        }
        //TODO: Rhythm: if IsActive:
        if (Input.GetKeyDown(KeyCode.Space)) {
            //Spacebar special
        } 
        else {
            if (Input.GetKeyDown(KeyCode.W)) {
                this.transform.Translate(0, 0, 1);
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                this.transform.Translate(-1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                this.transform.Translate(0, 0, -1);
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                this.transform.Translate(1, 0, 0);
            }

        }

        //TODO: Decide if we want this self-destruct code
        if(Input.GetKeyDown(KeyCode.Backspace)) {
            Destroy(gameObject);
        }
    }
}
