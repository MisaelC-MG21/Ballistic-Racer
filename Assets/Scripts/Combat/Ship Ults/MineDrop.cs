using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDrop : MonoBehaviour
{
    public GameObject mineObject;

    public float timeBetweenMines;

    UltCharge ultCharge;

    PlayerInput input;

    void Start()
    {
        ultCharge = GetComponentInParent<UltCharge>();
        input = GetComponentInParent<PlayerInput>();
    }

    void Update()
    {
        if (ultCharge.ultCharged)
        {
            if (input.powerUp)
            {
                StartCoroutine(DropMines());
            }
        }
    }

    IEnumerator DropMines()
    {
        Instantiate(mineObject, this.transform);
        yield return new WaitForSeconds(timeBetweenMines);
        Instantiate(mineObject, this.transform);
        yield return new WaitForSeconds(timeBetweenMines);
        Instantiate(mineObject, this.transform);
    }
}
