using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour {

    private Color originalColor; // store the color of the material of the object

	// Use this for initialization
	void Start () {

        // save the color of the material of self
        originalColor = this.GetComponent<Renderer>().material.color;
    }

    // detect when the mouse first hovers over self
    void OnMouseEnter ()
    {
        // set the new color of the material of self to magenta
        this.GetComponent<Renderer>().material.color = Color.magenta;
    }

    // detect when the mouse is first no longer hovering over self
    void OnMouseExit ()
    {
        // set the color of the material back to the original
        this.GetComponent<Renderer>().material.color = originalColor;
    }

    // detect when the mouse clicks on self
    void OnMouseDown ()
    {
        // destroy self (completely remove gameobject from scene)
        Destroy(this.gameObject);
    }

}
