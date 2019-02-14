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

	// Use this for initialization
	void Start () {
        check = GetComponentInChildren<CheckTrigger>();
        InvokeRepeating("UltimateCharge", chargeRate, chargeRate);
	}
	
	// Update is called once per frame
	void Update () {
        ultimateSlider.value = ultPower / (ultPowerMax * 1f);

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
