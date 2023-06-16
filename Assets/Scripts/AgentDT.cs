using UnityEngine;

public class AgentDT : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public float speed = 5f;
    public float playerDistanceThreshold = 5f;
    public float targetDistanceThreshold = 3f;

    void Update()
    {
        Vector3 direction = Vector3.zero;

        if ((target.transform.position - transform.position).magnitude < targetDistanceThreshold)
        {
            target.GetComponent<Cube>().setIsActive(true);
        }
        if (target.GetComponent<Cube>().getIsActive() && (player.transform.position - transform.position).magnitude < playerDistanceThreshold)
        {
            direction = -(player.transform.position - transform.position).normalized;
        }
        if (!target.GetComponent<Cube>().getIsActive() || (player.transform.position - transform.position).magnitude > playerDistanceThreshold)
        {
            direction = (player.transform.position - transform.position).normalized;
        }

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
