using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetManager : MonoBehaviour {

    public GameObject sun;
    public int id;
    public float radius;
    public int revolutions = -1;

    private GameObject body;
    private GameObject orbit;
    private GameObject start;
    public Text text;
    private float speed;
    public bool revolving = false;

	// Use this for initialization
	void Start () {
        body = transform.GetChild(2).gameObject;
        orbit = transform.GetChild(0).gameObject;
        start = transform.GetChild(1).gameObject;
        speed = Random.Range(25.0f, 120.0f);
        InitializePlanet();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(id.ToString()))
        {
            revolving = !revolving;
        }

        if (revolving)
        {
            body.transform.RotateAround(transform.position, transform.up, speed * Time.deltaTime);
        }
		
	}

    void InitializePlanet()
    {
        orbit.GetComponent<DrawOrbit>().xradius = radius;
        orbit.GetComponent<DrawOrbit>().yradius = radius;
        orbit.GetComponent<DrawOrbit>().segments = id * 10 + 30;

        body.transform.position = new Vector3(radius, 0, 0);
        start.transform.position = new Vector3(radius, 0, 0);

        float scale = Random.Range(3f, 5f);
        body.transform.localScale = new Vector3(scale, scale, scale);
        body.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

    }

    void UpdateRevolutions (GameObject collider)
    {
        if (collider == body)
        {
            revolutions++;
            text.text = "Planet " + id + ": " + revolutions;
        }
    }

}
