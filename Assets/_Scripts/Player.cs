using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            GameManager.UpdateHealth(5);
        }

        if (other.tag == "Boss") {
            GameManager.UpdateHealth(10);
        }
    }
}
