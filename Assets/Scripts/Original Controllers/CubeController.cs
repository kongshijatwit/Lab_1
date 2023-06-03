using UnityEngine;

public class CubeController : MonoBehaviour
{
    private GameController scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("GameController").GetComponent<GameController>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Add to score when the player hits a cube
            GameController.playerScore++;
            // Destroy the cube
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "NPC")
        {
            GameController.npcScore--;
            Destroy(gameObject);
        }
    }
}
