using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public float HP;
    public int health;

    void Update() {
        if (health <= 0) {
            GameManager.AddPoint(HP);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) { 

		if (other.CompareTag ("Hellwailer")) {
             health = health - 100;
         }

		if (other.CompareTag ("Archtronic")) {
                health = health - 35;
        }
    }
}
