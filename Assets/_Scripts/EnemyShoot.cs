using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public float speed = 20;
    public float shotForce = 8.0f;
	public float shotTTL = 5.0f;

	public float rechargeTime = 2.2f;
	public float startDelay = 5.0f;
    public float minDistance = 5;

    public GameObject projectile;
    public GameObject shotPoint;
    public AudioClip launchNoise;
    public GameObject playerObject;

    private Transform playerTransform;
    private Vector3 offset;
    private float lastShotTime;

	void Start () {
		lastShotTime = Time.time + startDelay;
        offset = new Vector3(0, 0, 3);
    }

    void Update() {
        playerTransform = playerObject.GetComponent<Transform>();

        if (Vector3.Distance(transform.position, playerTransform.position) < minDistance) {
            transform.LookAt(playerObject.transform);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position + offset, step);

            if (Time.time > lastShotTime + rechargeTime) {
                Shoot();
            }
        }
    }

    void Shoot () {
		lastShotTime = Time.time;

		if (launchNoise != null) {
			AudioSource.PlayClipAtPoint (launchNoise, shotPoint.transform.position, 1.0f);
		}

		GameObject newShot = Object.Instantiate (projectile, shotPoint.transform.position, transform.rotation);
        newShot.GetComponent<Rigidbody> ().AddForce (transform.forward * shotForce, ForceMode.Impulse);
        Object.Destroy (newShot, shotTTL);
	}
}
