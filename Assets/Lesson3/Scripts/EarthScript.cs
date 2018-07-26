using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour {

    public float speed = 30.0f; // speed of rotation
    private GameObject moon; // variable to store the moon gameobject in the scene

	// Use this for initialization
	void Start () {

        // find the moon gameobject in the scene
        moon = GameObject.Find("Moon");
       
	}
	
	// Update is called once per frame
	void Update () {

        // rotate self on y-axis
        transform.Rotate(Vector3.up * Time.deltaTime * speed);

        // rotate moon on y-axis at same rate
        moon.transform.Rotate(Vector3.up * Time.deltaTime * speed);
		
	}

}
