using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    public Transform cube;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        // agent.SetDestination(target.position);
        // agent.SetDestination(cube.position);
    }
}
