using UnityEngine;

public class PlayerControllerVR : MonoBehaviour
{
    private float speed = 10f;

    void Update()
    {
        // Gets input from the Oculus Touch Controller
        //Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        Vector2 input = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Apply movement from input
        Vector3 move = new Vector3(input.x, 0, input.y);
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}
