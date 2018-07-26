using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoCollisionDetection : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision entered!");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Still colliding...");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision exited.");
    }
}
