using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{

    public int numberOfLaps;

    
    // Start is called before the first frame update
    void Start() {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Check") {
            Debug.Log("Passed");
            CheckTrigger checkTrigger = other.GetComponent<CheckTrigger>();
            if(checkTrigger.checkpointReached) {
                Debug.Log("Passed");
                CompleteLap(checkTrigger);
            }
        }
    }

    public void CompleteLap(CheckTrigger checkTrigger) {
        if(checkTrigger.lapsCompleted < numberOfLaps) {
            checkTrigger.lapsCompleted++;
            checkTrigger.checkpointReached = false;
        } else {
            checkTrigger.finish.SetActive(true);
            checkTrigger.finalPosition = checkTrigger.position;
            checkTrigger.finished = true;
        }
    }

}
