using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TigerEating : MonoBehaviour {

    public GameObject feedTiger;
    public Text hungerText;
    public Text newFoodText;
    public Text goodFoodText;
    public Text nearFoodText;

    private Animator tigerAnimator;

	// Use this for initialization
	void Start () {
        tigerAnimator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckFoodPresent();
        UpdateText();
	}

    void CheckFoodPresent ()
    {
        if (!tigerAnimator.GetBool("nearFood") && feedTiger.GetComponent<FeedTiger>().foodPresent != null)
        {
            tigerAnimator.SetTrigger("newFood");
            tigerAnimator.SetBool("goodFood", feedTiger.GetComponent<FeedTiger>().isFoodGood);
        }
    }

    void UpdateText ()
    {
        hungerText.text = "Hunger: " + Mathf.Round(tigerAnimator.GetFloat("hunger"));
        newFoodText.text = "New Food: " + tigerAnimator.GetBool("newFood");
        goodFoodText.text = "Good Food: " + tigerAnimator.GetBool("goodFood");
        nearFoodText.text = "Near Food: " + tigerAnimator.GetBool("nearFood");
    }

}
