using UnityEngine;

public class AgentFSM : MonoBehaviour
{
    public enum State { CHASEPLAYER, CHASETARGET, FLEE };
    public State currentState = State.CHASEPLAYER;
    public Transform player;
    public Transform target;
    public Transform agent1;

    private float speed = 5f;
    public float agent1DistanceThreshold = 3f;

    void Update()
    {
        float distanceFromPlayer = (player.position - transform.position).magnitude;
        float distanceFromTarget = (target.position - transform.position).magnitude;
        float distanceFromAgent = (agent1.position - transform.position).magnitude;
        float playerTargetDistance = (player.position - target.position).magnitude;

        if (distanceFromPlayer < playerTargetDistance && distanceFromAgent > agent1DistanceThreshold)
        {
            currentState = State.CHASEPLAYER;
        }
        if (distanceFromTarget < distanceFromPlayer && distanceFromAgent > agent1DistanceThreshold)
        {
            currentState = State.CHASETARGET;
        }
        if (distanceFromAgent < agent1DistanceThreshold)
        {
            currentState = State.FLEE;
        }

        switch (currentState)
        {
            case State.CHASEPLAYER:
                Chase(player, false);
                break;
            
            case State.CHASETARGET:
                Chase(target, false);
                break;
            
            case State.FLEE:
                Chase(agent1, true);
                break;
        }
    }

    private void Chase(Transform target, bool isFleeing)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        if (isFleeing) direction *= -1;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
