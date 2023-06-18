using UnityEngine;
using UnityEngine.AI;

public class AgentExtra : MonoBehaviour
{
    enum State { PATROL, CHASEPLAYER, FLEEING, ATTACKING };
    [SerializeField] State currentState = State.CHASEPLAYER;  // Serialized for debugging ONLY

    [SerializeField] Vector3[] patrolList;
    int destinationIndex = 0;
    NavMeshAgent agent;

    [SerializeField] Transform player;
    [SerializeField] Transform cube;
    Cube cubeStatus;

    // Feel free to change these values
    float playerAggroDistance = 10f;
    float attackingDistance = 2.3f;
    float cubeDistanceThreshold = 6f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cubeStatus = cube.GetComponent<Cube>();
    }

    void Update()
    {
        float distanceFromPlayer = (player.position - transform.position).magnitude;
        float distanceFromCube = (cube.position - transform.position).magnitude;
        float playerCubeDistance = (player.position - cube.position).magnitude;

        // If the (player is too far away) or is (near an active cube) then go back to patrolling
        if (distanceFromPlayer > playerAggroDistance || (playerCubeDistance < cubeDistanceThreshold && cubeStatus.getIsActive()))
        {
            currentState = State.PATROL;
        }

        // If the (player is within chasing range) and is (not near an activated campfire)
        if (distanceFromPlayer < playerAggroDistance && !(playerCubeDistance < cubeDistanceThreshold && cubeStatus.getIsActive()))
        {
            currentState = State.CHASEPLAYER;
        }

        // If player is (within attacking distance)
        if (distanceFromPlayer <= attackingDistance)
        {
            currentState = State.ATTACKING;
        }

        // If the agent is caught (within an (activated campfire))
        if (cubeStatus.getIsActive() && distanceFromCube < cubeDistanceThreshold)
        {
            currentState = State.FLEEING;
        }


        switch (currentState)
        {   
            // Set patrol routes based on specific positions
            case State.PATROL:
                agent.SetDestination(patrolList[destinationIndex]);
                float dist = agent.remainingDistance;
                if (dist < .25f)
                {
                    destinationIndex = Random.Range(0, patrolList.Length);
                }
                break;

            // Chase the player
            case State.CHASEPLAYER:
                agent.SetDestination(player.position);
                break;

            // Run from the player rather than the campfire because the player is a higher threat
            case State.FLEEING:
                transform.Translate(-(player.position - transform.position).normalized * agent.speed * Time.deltaTime, Space.World);
                goto case State.PATROL;

            // Attacking currently only prints rather than do anything health related
            case State.ATTACKING:
                Debug.Log("You are being attacked oh no");
                break;
        }
    }
}
