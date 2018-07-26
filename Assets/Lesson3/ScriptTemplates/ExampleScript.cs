using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour {

    private int numCats = 6;

    void Start () {

        for (int i = 0; i <= 10; i++) {
            Debug.Log(i);
        }

        int j = 0;
        while (j <= 10) {
            Debug.Log(j);
            j++;
        }
        
    }

    void SayHello()
    {
        Debug.Log("Hello");
    }




}
