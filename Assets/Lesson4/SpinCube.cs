using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCube : MonoBehaviour {

    public float rotationSpeed { get; set; }
    private float toRotate = 0;
    private float rotation;

    private void Start()
    {
        rotationSpeed = 150f;
    }

    // Update is called once per frame
    void Update () {

        rotation = rotationSpeed * Time.deltaTime;

        if (toRotate - rotation >= 0)
        {
            toRotate -= rotation;
        } else
        {
            rotation = toRotate;
            toRotate = 0;
        }

        transform.Rotate(0, rotation, 0);
	}

    public void SpinAround ()
    {
        toRotate = 360f;
    }
}
