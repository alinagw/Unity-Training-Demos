using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObjectOnHover : MonoBehaviour {

    // TODO: declare a public material object to store your highlight material
    // attach the material in the inspector
    // create a solid, bright color material so it stands out on your object
    public Material highlight;

    // TODO: declare a private gameobject to store the object currently hovered over
    // use to access the active object to highlight it
    private GameObject activeObject;
    // TODO: declare a private material to store the hovered over object's original material
    // use to reset the active object's material back to normal once you're not hovering over it
    private Material startMaterial;

	// Update is called once per frame
	void Update () {

        // creates a ray fired from the main camera through the mouse position on the screen
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // stores the information about the hit when the ray hits an object in the scene
        // look up RaycastHit in the Unity Scripting API to see what properties and methods are available
        RaycastHit hit;

        // casts a physics ray from the main camera in front of the player and detects if it hits an object
        // if it hits something the data will be stored in the hit variable
        // the ray is only cast a max distance of 5.0 so the player must be close to an object for it to highlight
        if (Physics.Raycast(ray, out hit, 5.0f))
        {
            // this body of code will run if the raycast hits an object

            // TODO: access the tag of the gameobject hit by the raycast and check IF it matches
            // use a tag to apply to your gameobjects that have interactable features so only they can be highlighted

                // if the tag is a match...
                // TODO: call the highlightObject function and pass the hit gameobject as the argument

            // TODO: create a condition for if the tag does not match
            // if your raycast hits something that isn't interactable, we want to ignore it
            
                // if the tag is not a match...
                // TODO: call the resetActiveObject function

            if (hit.collider.gameObject.tag == "Interactable")
            {
                highlightObject(hit.collider.gameObject);
            } else
            {
                resetActiveObject();
            }
            
        } else
        {
            // this body of code will run if the raycast does NOT hit an object

            // TODO: call the resetActiveObject function
            resetActiveObject();
        }       
		
	}

    // function that will add the highlight material to the object hit by the raycast
    // takes the parameter of the gameobject hit by the raycast
    void highlightObject (GameObject objectHit)
    {

        // TODO: check IF the current active object is different from the obj parameter

            // if the object is different...
            // TODO: call the resetActiveObject function
            // TODO: set the active object to the new object
            // TODO: set the material placeholder to the original material of the new object
            // TODO: set the material of the active object to the highlight material
        if (activeObject != objectHit)
        {
            resetActiveObject();
            activeObject = objectHit;
            startMaterial = objectHit.GetComponent<MeshRenderer>().material;
            activeObject.GetComponent<MeshRenderer>().material = highlight;
        }

    }

    // function that will reset the active object material and variables when no object is hovered over
    void resetActiveObject()
    {
        // TODO: check IF the active object is not null

            // if the active object isn't null...
            // TODO: reset the material of the active object to its original material
            // TODO: set the active object to null
            // TODO: set the start material to null
        if (activeObject != null)
        {
            activeObject.GetComponent<MeshRenderer>().material = startMaterial;
            activeObject = null;
            startMaterial = null;
        } 
    }
}
