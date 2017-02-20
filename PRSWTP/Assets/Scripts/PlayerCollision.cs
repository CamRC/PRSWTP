﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<PlayerScript>().health--;
			Debug.Log ("ouch");
			//for some reason, this is not the function that modifies player health
			//oh it's just because it's colliding with the sword
        }

        bool controllable = gameObject.GetComponent<PlayerScript>().getControllable();

        if (controllable && col.gameObject.tag == "Player")
        {
            kill();
        }
    }

    //Literally the most satisfying function in this entire project.
    public void kill()
    {
        Destroy(this.gameObject);
    }
}
