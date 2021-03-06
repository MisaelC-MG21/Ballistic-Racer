﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAI : MonoBehaviour
{
    [Range(0, 1)]
    public float acceleration;

    AIPath path;

    List<Transform> nodes = new List<Transform>();
    int currentNode = 0;

    int shootableMask;

    [HideInInspector] public bool swapRotation;
    [HideInInspector] public float posOrNeg;

    PlayerInput input;

    PlayerShooting shooting;

    void Start()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        path = FindObjectOfType<AIPath>();
        input = GetComponent<PlayerInput>();
        shooting = GetComponentInChildren<PlayerShooting>();

        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();

        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    void FixedUpdate()
    {
        CheckNodeDistance();
        if (input.controllerNumber == 0)
        {
            Rudder();
            Accelerate();
            if (input.canShoot)
            {
                DetectEnemy();
            }
        }
    }

    void DetectEnemy()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, shooting.range, shootableMask))
        {
            input.shoot = true;
        }
        else
        {
            input.shoot = false;
        }
    }

    void Rudder()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);

        float directionX;
        float directionY;

        directionX = relativeVector.x / relativeVector.magnitude;
        directionY = relativeVector.y / relativeVector.magnitude;

        if (!swapRotation)
        {
            input.rudder = directionX;
        }
        else
        {
            input.rudder = directionY * posOrNeg;
        }
    }

    void Accelerate()
    {
        input.accelerate = acceleration;
    }

    void CheckNodeDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 50f)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }
}
