using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	public GameObject explosion; 
	public AudioClip explodeNoise;
    public float explosiveForce = 10.0f;
    public float explosionRadius = 5.0f;

    void OnTriggerEnter (Collider collision) {
		if (explosion != null) {
			GameObject newExplosion = (GameObject)Instantiate (explosion);
			newExplosion.transform.position = this.transform.position;
			Destroy (newExplosion, 4.0f);
		}

		if (explodeNoise != null) {
			AudioSource.PlayClipAtPoint (explodeNoise, transform.position, 1.0f);
		}

		Rigidbody target = collision.GetComponent<Rigidbody>();
		if(target != null) {
			target.AddExplosionForce (explosiveForce, transform.position, explosionRadius, 1.0f, ForceMode.Impulse);
		}
        Destroy (gameObject);
	}
}
