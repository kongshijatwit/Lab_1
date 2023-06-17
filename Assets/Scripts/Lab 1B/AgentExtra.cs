using UnityEngine;

public class AgentExtra : MonoBehaviour
{
    private enum State { PATROL, CHASEPLAYER, FLEEING, ATTACKING };
    private State currentState = State.CHASEPLAYER;

    [SerializeField] Transform player;
    [SerializeField] Transform cube;
    Cube cubeStatus;

    float speed = 5f;
    float cubeDistanceThreshold = 10f;

    void Start()
    {
        cubeStatus = cube.GetComponent<Cube>();
    }

    void Update()
    {
        float distanceFromPlayer = (player.position - transform.position).magnitude;
        float distanceFromCube = (cube.position - transform.position).magnitude;

        if (cubeStatus.getIsActive())
        {
            
        }
    }
}
