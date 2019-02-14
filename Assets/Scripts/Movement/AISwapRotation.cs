using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISwapRotation : MonoBehaviour
{
    public bool positive;
    public bool switchRotation;

    float posOrNeg;

    void Start()
    {
        if (positive)
        {
            posOrNeg = 1f;
        }
        else
        {
            posOrNeg = -1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerInput>().controllerNumber == 0)
        {
            ShipAI ship = other.GetComponentInParent<ShipAI>();
            ship.posOrNeg = posOrNeg;
            if (switchRotation)
            {
                ship.swapRotation = true;
            }
            else
            {
                ship.swapRotation = false;
            }
        }
    }
}
