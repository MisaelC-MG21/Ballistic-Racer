using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltCharge : MonoBehaviour {

    public Slider ultimateSlider;

    public int ultPower;

    public int ultPowerMax;

    public float chargeRate;

    public bool ultCharged;

    int chargeSpeed;

    CheckTrigger check;

    PlayerInput input;

    bool invokeStart;

    // Use this for initialization
    void Start () {
        input = GetComponent<PlayerInput>();
        check = GetComponentInChildren<CheckTrigger>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if(!invokeStart) {
            if(ShipSetup.raceStarted) {
                InvokeRepeating("UltimateCharge", chargeRate, chargeRate);
                invokeStart = true;
            }
        }
        if(input.controllerNumber != 0) {
            ultimateSlider.value = ultPower / (ultPowerMax * 1f);
        }

        chargeSpeed = check.position + 10;

        if(ultPower == ultPowerMax) {
            ultCharged = true;
        } else {
            ultCharged = false;
        }
        if(ultPower > ultPowerMax) {
            ultPower = ultPowerMax;
        }
	}


    void UltimateCharge() {
        ultPower += chargeSpeed;
    }
}
