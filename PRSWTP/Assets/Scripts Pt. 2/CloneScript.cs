﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script is intended to represent all the past selves
 * in order to differentiate current/past selves from each
 * other. 
 * 
 * It might not work. Sorry :(
 * 
*/

public class CloneScript : MonoBehaviour {
    private float gameTicks;

    public Vector3[] checkpointLocations;

    public GameObject PlayerScript;

    // Use this for initialization
    void Start () {
        //copied from playerscript also
        if (ValueHolder.isPastSelfSpawning == false)
        {
            Debug.Log("CHECKPOINT " + ValueHolder.checkpointNumber);
            //The checkpoints are indexed from 1, the locations are indexed from 0
            Vector3 newPos = checkpointLocations[ValueHolder.checkpointNumber];
            Debug.Log("Pos: " + newPos.x + ", " + newPos.y + ", " + newPos.z);
            this.transform.position = checkpointLocations[ValueHolder.checkpointNumber];
        }
        else
        {
            ValueHolder.isPastSelfSpawning = false;
        }


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setRotation()
    {
        //insert math here that calculates differences
        //in x values from setPosition :)
    }

    //taken from PlayerScript - sets position of the clone
    public void setPosition(Vector3 vector)
    {
        var marker = TrackMovement.MARKER;
        //this is always true?
        if (marker != null && Mathf.Abs((vector - marker).magnitude) < float.Epsilon)
        {
            Debug.Log("oh no!");
            kill();
        }
        transform.position = vector;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //PlayerScript.GetComponent<PlayerScript>().health--;
            Debug.Log("You colllided with your past self!!");
            Debug.Log("the man loved trees");
        }
    }

    public void kill()
    {
        Destroy(this.gameObject);
    }

}
