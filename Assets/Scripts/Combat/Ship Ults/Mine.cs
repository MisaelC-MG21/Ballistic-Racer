using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

    public int damageAmount;

    public GameObject parent;

    public Collider detection;

	// Use this for initialization
	void Start () {
        
	}
	
	

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.layer == LayerMask.NameToLayer("Shootable")) {

        
            other.GetComponent<PlayerHealth>().currentHealth -= damageAmount;
            Destroy(parent);
        }
    }

    IEnumerator Fuse() {
        yield return new WaitForSeconds(1);
        detection.enabled = true;
    }

}
