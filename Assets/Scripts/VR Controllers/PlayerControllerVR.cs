using UnityEngine;
using UnityEngine.XR;

public class PlayerControllerVR : MonoBehaviour
{
    private float speed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Gets input from the Oculus Touch Controller
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        // Apply movement from input
        Vector3 move = new Vector3(input.x, 0, input.y);
        transform.Translate(move * speed * Time.deltaTime);
    }
}
