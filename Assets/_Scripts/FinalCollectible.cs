using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCollectible : MonoBehaviour {

    public GameObject particleEffect;
    private float HP = 1000;

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Debug.Log("hit Trigger");
            particleEffect.SetActive(true);
            GameManager.gameOver = true;
            GameManager.AddPoint(HP);
            Destroy(gameObject);
          }
    }
}
