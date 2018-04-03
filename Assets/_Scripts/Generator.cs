using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject prefabToGenerate;
    public Transform[] stormTransforms;
    public float waitTime = 30;


    private Transform startStorm;
    private bool notGenerated;
    private bool found = false;

    private float lastTime = 0;

    void Start() {
        Instantiate(prefabToGenerate, transform);
    }

    void Update() {
       if (Time.time > lastTime + waitTime) {
            System.Random random = new System.Random();
            startStorm = stormTransforms[random.Next(stormTransforms.Length)];

            lastTime += Time.time;
            Object.Instantiate(prefabToGenerate, transform);
        }
    }
}
