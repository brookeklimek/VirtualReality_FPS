using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoopingBehavior : MonoBehaviour {

		public float speed;
		private Vector3 pivot; 

		void Update () {
			pivot = new Vector3 (0, 40, 0);
			transform.RotateAround(pivot, Vector3.up, speed * Time.deltaTime);
		}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Temple") {
			return;
		}
	}
}
