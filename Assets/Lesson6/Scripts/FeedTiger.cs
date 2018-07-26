using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedTiger : MonoBehaviour {

    public GameObject tiger;
    public GameObject[] foods = new GameObject[6];
    public GameObject foodPresent;
    public bool isFoodGood;


    private void OnMouseDown()
    {
        if (foodPresent == null)
        {
            int newFood = Random.Range(0, foods.Length);
            foodPresent = Instantiate(foods[newFood], this.transform);
            foodPresent.transform.localPosition = new Vector3(0, 0.1f, 0);
            foodPresent.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            
            if (newFood > 2)
            {
                isFoodGood = true;
            } else
            {
                isFoodGood = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == tiger)
        {
            Debug.Log("Tiger");
            tiger.GetComponent<Animator>().SetBool("nearFood", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == tiger)
        {
            tiger.GetComponent<Animator>().SetBool("nearFood", false);
        }
        Destroy(foodPresent.gameObject);
    }
}
