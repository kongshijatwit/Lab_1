using UnityEngine;
using UnityEngine.AI;

public class AgentExtra : MonoBehaviour
{
    enum State { PATROL, CHASEPLAYER, FLEEING, ATTACKING };
    [SerializeField] State currentState = State.CHASEPLAYER;

    [SerializeField] Vector3[] patrolList;
    int destinationIndex = 0;
    NavMeshAgent agent;

    [SerializeField] Transform player;
    [SerializeField] Transform cube;
    Cube cubeStatus;

    float speed = 5f;
    float playerAggroDistance = 10f;
    float attackingDistance = 2.3f;
    float cubeDistanceThreshold = 6f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cubeStatus = cube.GetComponent<Cube>();
        speed = agent.speed;
    }

    void Update()
    {
        float distanceFromPlayer = (player.position - transform.position).magnitude;
        float distanceFromCube = (cube.position - transform.position).magnitude;
        float playerCubeDistance = (player.position - cube.position).magnitude;

        // If the player is too far away or is near an active cube then go back to patrolling
        if (distanceFromPlayer > playerAggroDistance || (playerCubeDistance < cubeDistanceThreshold && cubeStatus.getIsActive()))
        {
            currentState = State.PATROL;
        }
        if (distanceFromPlayer < playerAggroDistance && !(playerCubeDistance < cubeDistanceThreshold && cubeStatus.getIsActive()))
        {
            currentState = State.CHASEPLAYER;
        }
        if (distanceFromPlayer <= attackingDistance)
        {
            currentState = State.ATTACKING;
        }
        if (cubeStatus.getIsActive() && distanceFromCube < cubeDistanceThreshold)
        {
            currentState = State.FLEEING;
        }


        switch (currentState)
        {
            case State.PATROL:
                // Set patrol routes based on specific positions
                agent.SetDestination(patrolList[destinationIndex]);
                float dist = agent.remainingDistance;
                if (dist < .25f)
                {
                    destinationIndex = Random.Range(0, patrolList.Length);
                }
                break;
            
            case State.CHASEPLAYER:
                // Chase the player
                agent.SetDestination(player.position);
                break;

            case State.FLEEING:
                transform.Translate(-(player.position - transform.position).normalized * speed * Time.deltaTime, Space.World);
                goto case State.PATROL;

            case State.ATTACKING:
                Debug.Log("You are being attacked oh no");
                break;
        }
    }
}
