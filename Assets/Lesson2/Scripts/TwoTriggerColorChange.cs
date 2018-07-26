using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoTriggerColorChange : MonoBehaviour {

    public Material highlightMaterial;
    private Material originalMaterial;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger!");
        originalMaterial = other.gameObject.GetComponent<MeshRenderer>().material;
        other.gameObject.GetComponent<MeshRenderer>().material = highlightMaterial;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited.");
        other.gameObject.GetComponent<MeshRenderer>().material = originalMaterial;
    }
}
