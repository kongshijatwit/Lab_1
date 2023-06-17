using UnityEngine;

public class CameraControllerVR : MonoBehaviour
{
    private float rotationSpeed = 10f;

    void Update()
    {
        //Vector2 input = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        float input = 1f;
        transform.RotateAround(Vector3.zero, Vector3.up, input * rotationSpeed * Time.deltaTime);
    }
}
