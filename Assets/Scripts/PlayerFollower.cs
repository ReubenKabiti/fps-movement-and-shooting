using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerFollower : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    public float seekDistance = 3;
    public float attackDistance = 2;

    Vector3 returnPoint;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        returnPoint = transform.position;
        player = FindObjectOfType<PlayerMovement>().transform;
    }


    void Update()
    {
        float distance = (transform.position - player.position).magnitude;
        if (distance <= seekDistance && distance > attackDistance)
            agent.destination = player.position;
        else if (distance <= attackDistance)
        {
            // attack here
            agent.destination = transform.position;
        }
        else
        {
            agent.destination = returnPoint;
        }
    }
}
