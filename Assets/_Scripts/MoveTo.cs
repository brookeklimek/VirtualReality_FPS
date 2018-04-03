using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour {

    public GameObject playerObject;
    public float minDistance = 5;

    private NavMeshAgent agent;
    private Transform playerTransform;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
     }

     void Update() {
        playerTransform = playerObject.GetComponent<Transform>();
        transform.LookAt(playerTransform);
        agent.SetDestination(playerTransform.position);
    }
}