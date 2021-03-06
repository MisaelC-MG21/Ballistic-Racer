﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTrigger : MonoBehaviour
{
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

    void Start()
    {
        miniMapIcon.SetActive(true);
        checksGO = GameObject.FindGameObjectsWithTag("Check");
        foreach (GameObject check in checksGO)
        {
            checks.Add(check.GetComponent<CheckTrigger>());
        }
        numberOfRacers = checksGO.Length;
        position = numberOfRacers;
        checkpoint = FindObjectOfType<Checkpoint>();

        lastPoint = GameObject.FindGameObjectWithTag("Finish");
    }

    void Update()
    {
        lastPointDistance = Vector3.Distance(transform.position, lastPoint.transform.position);
        lapNumber.text = lapsCompleted + "/" + checkpoint.numberOfLaps;
        if (position == 1)
        {
            racePosition.text = position + "st";
        }
        else if (position == 2)
        {
            racePosition.text = position + "nd";
        }
        else if (position == 3)
        {
            racePosition.text = position + "rd";
        }
        else if (position >= 4)
        {
            racePosition.text = position + "th";
        }

        foreach (CheckTrigger check in checks)
        {
            if (check != this && check.lapsCompleted > lapsCompleted)
            {
                position++;
            }
            else if (check != this && check.lapsCompleted < lapsCompleted)
            {
                position--;
            }
            else if (check != this && check.lapsCompleted == lapsCompleted)
            {
                if (check.pointID > pointID && check != this)
                {
                    position++;
                }
                else if (check.pointID < pointID && check != this)
                {
                    position--;
                }
                else if (check.pointID == pointID && check != this)
                {
                    if (check.lastPointDistance > lastPointDistance && check != this)
                    {
                        position++;
                    }
                    else if (check.lastPointDistance < lastPointDistance && check != this)
                    {
                        position--;
                    }
                }
            }
        }
        if (position <= 1)
        {
            position = 1;
        }
        else if (position >= numberOfRacers)
        {
            position = numberOfRacers;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")
        {
            checkpointReached = true;
            Debug.Log("Passed");
        }
        if (other.tag == "Respawn" || other.tag == "Checkpoint" || other.tag == "Finish")
        {
            playerHealth.respawnPoint = other.transform;
            lastPoint = other.gameObject;
        }
        if (other.tag == "Respawn" || other.tag == "Checkpoint")
        {
            pointID++;
        }
        if (other.tag == "Finish")
        {
            pointID = 0;
        }
    }
}
