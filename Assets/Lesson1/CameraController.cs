using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed = 50.0f;

    // Update is called once per frame
	void Update () {

        Vector3 rotation = new Vector3(-Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0.0f);
        transform.Rotate(rotation * speed * Time.deltaTime);

        float angle = transform.localEulerAngles.x;
        angle = (angle > 180) ? angle - 360 : angle;
        transform.localEulerAngles = new Vector3(Mathf.Clamp(angle, -60.0f, 60.0f), transform.localEulerAngles.y, 0.0f);
    }
}
