using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonScript : MonoBehaviour {

    public GameObject earth; // store the earth gameobject from the scene in the inspector
	
	// Update is called once per frame
	void Update () {

        // detect if "p" key is pressed
        if (Input.GetKeyDown("p"))
        {
            // if the moon does not have a parent object
            if (transform.parent == null)
            {
                // set the moon's parent as the earth
                transform.SetParent(earth.transform);
            }
            // if the mooon does have a parent
            else
            {
                // remove the moon's parent
                transform.parent = null;
            }
        }

        // detect if "g" key is pressed
        if (Input.GetKeyDown("g"))
        {
            // toggle gravity on the rigidbody on / off
            this.GetComponent<Rigidbody>().useGravity = !this.GetComponent<Rigidbody>().useGravity;
        }

        // call the move moon function every frame
        MoveMoon();
       
	}

    // function to use arrow keys to move the moon in the scene
    void MoveMoon ()
    {
        // detect if the horizontal axis (aka the right and left arrow keys) are being pressed
        float moveHorizontal = Input.GetAxis("Horizontal");
        // detect if the vertical axis (aka the up and down arrow keys) are being pressed
        float moveVertical = Input.GetAxis("Vertical");
        // translate / move the moon the x and y amounts depending on the arrow keys within world space
        transform.Translate(moveHorizontal, moveVertical, 0, Space.World);
    }

}
