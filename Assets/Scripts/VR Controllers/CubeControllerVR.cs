using UnityEngine;
using OculusSampleFramework;

public class CubeControllerVR : OVRGrabbable
{
    private GameController scoreManager;

    public new void Start()
    {
        scoreManager = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.playerScore++;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "NPC")
        {
            GameController.npcScore--;
            Destroy(gameObject);
        }
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        scoreManager.OnCubeGrabbed();
    }
}
