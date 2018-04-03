using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {

	public static bool playerInRange;

	void Start () {

		playerInRange = true;
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			playerInRange = true;
			Debug.Log ("player detected");
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			playerInRange = false;
			Debug.Log ("player exit");

		}
	}
}
