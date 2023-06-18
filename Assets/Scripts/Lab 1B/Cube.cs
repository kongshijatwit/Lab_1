using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private bool isActivated = false;  // Serialized for debugging ONLY

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
        {
            isActivated = !isActivated;
        }
        GetComponent<MeshRenderer>().material.color = isActivated ? Color.red : Color.yellow;
    }

    public bool getIsActive()
    {
        return isActivated;
    }

    public void setIsActive(bool newState)
    {
        isActivated = newState;
    }
}
