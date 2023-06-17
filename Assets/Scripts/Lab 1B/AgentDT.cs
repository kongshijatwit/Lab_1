using UnityEngine;

public class AgentDT : MonoBehaviour
{
    public Transform player;
    public Transform target;
    private Cube targetStatus;

    private float speed = 5f;
    public float playerDistanceThreshold = 5f;
    public float targetDistanceThreshold = 3f;

    private void Start() 
    {
        targetStatus = target.GetComponent<Cube>();
    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;
        float distanceFromPlayer = (player.position - transform.position).magnitude;
        float distanceFromTarget = (target.position - transform.position).magnitude;

        if (distanceFromTarget < targetDistanceThreshold)
        {
            targetStatus.setIsActive(true);
        }
        if (targetStatus.getIsActive() && distanceFromPlayer < playerDistanceThreshold)
        {
            direction = -(player.position - transform.position).normalized;
        }
        if (!targetStatus.getIsActive() || distanceFromPlayer > playerDistanceThreshold)
        {
            direction = (player.position - transform.position).normalized;
        }

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
