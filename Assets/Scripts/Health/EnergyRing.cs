using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRing : MonoBehaviour {

    public int energyAmmount;

    public float timeToRestart;

    bool deactivated;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ActivationTime() {
        deactivated = true;
        yield return new WaitForSeconds(timeToRestart);
        deactivated = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Shootable")) {
            if(!deactivated) {
                other.GetComponent<PlayerHealth>().currentHealth += energyAmmount;
                StartCoroutine(ActivationTime());
            }
        }
    }
}
