using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool isActivated = false;

    public bool getIsActive()
    {
        return isActivated;
    }

    public void setIsActive(bool newState)
    {
        isActivated = newState;
    }
}
