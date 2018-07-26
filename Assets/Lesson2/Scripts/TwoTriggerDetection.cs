using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoTriggerDetection : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger!");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Still in trigger...");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited.");
    }
}
