using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRevolution : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        transform.parent.SendMessage("UpdateRevolutions", other.gameObject);
    }
}
