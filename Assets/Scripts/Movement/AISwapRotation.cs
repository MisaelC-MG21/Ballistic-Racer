using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISwapRotation : MonoBehaviour {

    public bool positive;
    public bool switchRotation;

    float posOrNeg;

	// Use this for initialization
	void Start () {
        if(positive) {
            posOrNeg = 1f;
        } else {
            posOrNeg = -1f;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponentInParent<PlayerInput>().controllerNumber == 0) {
            ShipAI ship = other.GetComponentInParent<ShipAI>();
            ship.posOrNeg = posOrNeg;
            if(switchRotation) {
                ship.swapRotation = true;
            } else {
                ship.swapRotation = false;
            }
        }
    }
}
