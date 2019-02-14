using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTrigger : MonoBehaviour {
    public Text lapNumber;

    public Text racePosition;

    public GameObject finish;

    public int lapsCompleted;

    Checkpoint checkpoint;

    public PlayerHealth playerHealth;

    public bool checkpointReached;

    GameObject[] checksGO;

    List<CheckTrigger> checks = new List<CheckTrigger>();

    GameObject lastPoint;

    public GameObject miniMapIcon;

    public int position;

    public float lastPointDistance;

    public int pointID;

    int numberOfRacers;

    PlayerInput input;

    [HideInInspector] public int finalPosition;
    [HideInInspector] public bool finished;

    // Start is called before the first frame update
    void Start() {
        input = GetComponentInParent<PlayerInput>();
        miniMapIcon.SetActive(true);
        checksGO = GameObject.FindGameObjectsWithTag("Check");
        foreach(GameObject check in checksGO) {
            if(check != this) {
                checks.Add(check.GetComponent<CheckTrigger>());
            }
        }
        numberOfRacers = checksGO.Length;
        position = numberOfRacers;
        checkpoint = FindObjectOfType<Checkpoint>();

        lastPoint = GameObject.FindGameObjectWithTag("Finish");
    }

    // Update is called once per frame
    void Update() {
        if(finished) {
            if(input.controllerNumber != 0) {
                if(finalPosition == 1) {
                racePosition.text = finalPosition + "st";
            } else if(finalPosition == 2) {
                racePosition.text = finalPosition + "nd";
            } else if(finalPosition == 3) {
                racePosition.text = finalPosition + "rd";
            } else if(finalPosition >= 4) {
                racePosition.text = finalPosition + "th";
            }
            
                input.controllerNumber = 0;
            }
        }
        lastPointDistance = Vector3.Distance(transform.position, lastPoint.transform.position);
        if(input.controllerNumber != 0 && !finished) {
            lapNumber.text = lapsCompleted + "/" + checkpoint.numberOfLaps;
            if(position == 1) {
                racePosition.text = position + "st";
            } else if(position == 2) {
                racePosition.text = position + "nd";
            } else if(position == 3) {
                racePosition.text = position + "rd";
            } else if(position >= 4) {
                racePosition.text = position + "th";
            }
        }

        foreach(CheckTrigger check in checks) {
            if(check.lapsCompleted > lapsCompleted) {
                if(position != numberOfRacers) {
                    position++;

                } else if(position > numberOfRacers) {
                    position = numberOfRacers;
                }

            }
            if(check.lapsCompleted < lapsCompleted) {
                if(position != 1) {
                    position--;

                } else if(position < 1) {
                    position = 1;
                }

            }
            if(check.lapsCompleted == lapsCompleted) {
                if(check.pointID > pointID) {
                    if(position != numberOfRacers) {
                        position++;

                    } else if(position > numberOfRacers) {
                        position = numberOfRacers;
                    }
                }
                if(check.pointID < pointID) {
                    if(position != 1) {
                        position--;

                    } else if(position < 1) {
                        position = 1;
                    }
                }
                if(check.pointID == pointID) {
                    if(check.lastPointDistance > lastPointDistance) {
                        if(position != numberOfRacers) {
                            position++;

                        } else if(position > numberOfRacers) {
                            position = numberOfRacers;
                        }
                    }
                    if(check.lastPointDistance < lastPointDistance) {
                        if(position != 1) {
                            position--;

                        } else if(position < 1) {
                            position = 1;
                        }
                    }
                }
            }
        }
        

        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Checkpoint") {
            checkpointReached = true;
            Debug.Log("Passed");
        }
        if(other.tag == "Respawn" || other.tag == "Checkpoint" || other.tag == "Finish") {
            playerHealth.respawnPoint = other.transform;
            lastPoint = other.gameObject;
        }
        if(other.tag == "Respawn" || other.tag == "Checkpoint") {
            pointID++;
        }
        if(other.tag == "Finish") {
            pointID = 0;
        }
    }

    
}
