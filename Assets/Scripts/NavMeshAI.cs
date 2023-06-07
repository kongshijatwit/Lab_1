using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform cube;

    public Transform[] waypointArray;
    public int waypointIndex = 0;
    private Vector3 cubePos;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypointArray[0].position);
        cubePos = new Vector3(cube.position.x, 0, cube.position.z);
    }

    void Update()
    {
        Vector3 currPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 waypointPos = new Vector3(waypointArray[waypointIndex].position.x, 0, waypointArray[waypointIndex].position.z);
        if (currPos == waypointPos && currPos != cubePos) agent.SetDestination(SetNextDest());
    }

    private Vector3 SetNextDest()
    {
        waypointIndex = Random.Range(0, waypointArray.Length);
        return waypointArray[waypointIndex].position;
    }
}
