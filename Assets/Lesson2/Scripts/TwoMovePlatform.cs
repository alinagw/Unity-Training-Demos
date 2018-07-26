using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoMovePlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(new Vector3(0.0f, 3.0f, 3.0f), new Vector3(0.0f, 3.0f, -3.0f), Mathf.PingPong(Time.time/2, 1));
    }
}
