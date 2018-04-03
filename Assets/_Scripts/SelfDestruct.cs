using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(Time.time);
        Destroy(gameObject, 10.0f);

        Debug.Log("Dustorm Destroyed " + Time.time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
