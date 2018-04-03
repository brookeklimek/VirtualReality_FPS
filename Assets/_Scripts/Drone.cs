using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour {

    public GameObject playerObject;

    public float speed = 20;
	public float shotStrength = 10;
	public float minDistance = 5;

    private Transform playerTransform;
    private Vector3 offset;

    void Start() {
        offset = new Vector3(0, 0, 3);    
    }

    void Update() {
        playerTransform = playerObject.GetComponent<Transform>();
       
		if (Vector3.Distance (transform.position, playerTransform.position) < minDistance) {
            transform.LookAt(playerObject.transform);

            float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, playerTransform.position + offset, step);
		} 
	}
}
