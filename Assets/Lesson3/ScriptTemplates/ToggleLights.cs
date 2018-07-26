using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Turn lights on / off on mouse click
 * Attach this script to the light switch GameObject
 */

public class ToggleLights : MonoBehaviour {

    // TODO: declare public GameObject to store light object in scene
    // TODO: attach light GameObject in inspector



    //TODO: use function to detect mouse click

        // within mouse click function...
        // TODO: get light component from light GameObject
        // TODO: toggle light component enabled true/false OR adjust intensity of light component
        // HINT: use the NOT operator !

    public GameObject light;

    void OnMouseDown () {
        light.GetComponent<Light>().enabled = !light.GetComponent<Light>().enabled;  
    }
}