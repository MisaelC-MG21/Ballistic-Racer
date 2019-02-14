using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public Transform target;

    public Camera mainCam;

    public Transform[] cameraPoints;

    public PlayerInput inputs;

    public bool position1, position2, front;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = target.rotation;
        mainCam.transform.position = cameraPoints[0].position;
        mainCam.transform.rotation = cameraPoints[0].rotation;
        position1 = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position;

        Quaternion rotation = Quaternion.Euler(target.eulerAngles.x, target.eulerAngles.y, target.eulerAngles.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.1f);

        if (inputs.cameraView)
        {
            if (position1)
            {
                front = false;
                position2 = true;
                position1 = false;
            }
            else if (position2)
            {
                position1 = false;
                front = true;
                position2 = false;
            }
            else if (front)
            {
                position2 = false;
                position1 = true;
                front = false;
            }
        }

        if (position1)
        {
            mainCam.transform.position = cameraPoints[0].position;
            mainCam.transform.rotation = cameraPoints[0].rotation;
        }
        if (position2)
        {
            mainCam.transform.position = cameraPoints[1].position;
            mainCam.transform.rotation = cameraPoints[1].rotation;
        }
        if (front)
        {
            mainCam.transform.position = cameraPoints[2].position;
            mainCam.transform.rotation = cameraPoints[2].rotation;
        }
    }
}
