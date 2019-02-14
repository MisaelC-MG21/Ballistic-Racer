using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : MonoBehaviour
{
    public float hellDuration;

    public GameObject[] normalGuns;
    public GameObject hellGunsGimbal;

    public Animator anim;

    bool continuousFire;

    UltCharge ultCharge;
    PlayerInput input;

    void Start()
    {
        ultCharge = GetComponent<UltCharge>();
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (ultCharge.ultCharged)
        {
            if (input.powerUp)
            {
                StartCoroutine(RaiseHell());
            }
        }

        if (continuousFire)
        {
            input.shoot = true;
        }
    }

    IEnumerator RaiseHell()
    {
        RotateGimbal();
        continuousFire = true;
        yield return new WaitForSeconds(hellDuration);
        StopRotation();
        continuousFire = false;
    }

    void RotateGimbal()
    {
        anim.SetBool("Rotate", true);
        foreach (GameObject gun in normalGuns)
        {
            gun.SetActive(false);
        }
        hellGunsGimbal.SetActive(true);
    }

    void StopRotation()
    {
        anim.SetBool("Rotate", false);
        hellGunsGimbal.SetActive(false);
        foreach (GameObject gun in normalGuns)
        {
            gun.SetActive(true);
        }
    }
}
