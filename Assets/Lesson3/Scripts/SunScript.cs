using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour {

    public GameObject starPrefab; // save the prefab of the star object
	
	// Update is called once per frame
	void Update () {

        // detect if the "s" key is pressed
        if (Input.GetKey("s"))
        {
            // generate a new random x, y, z coordinate position within the frame of the camera (these numbers I estimated myself)
            Vector3 starPosition = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-20.0f, 70.0f), 0);

            // add a new star object to the scene at the generated position and initial rotation
            Instantiate(starPrefab, starPosition, Quaternion.identity);
        }
		
	}

    // detect when the mouse clicks on self
    void OnMouseDown()
    {
        // enable / disable the light component on the sun object
        this.GetComponent<Light>().enabled = !this.GetComponent<Light>().enabled;
    }

}
