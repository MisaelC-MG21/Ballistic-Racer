using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRing : MonoBehaviour
{
    public int energyAmmount;

    public float timeToRestart;

    bool deactivated;

    IEnumerator ActivationTime()
    {
        deactivated = true;
        yield return new WaitForSeconds(timeToRestart);
        deactivated = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            if (!deactivated)
            {
                other.GetComponent<PlayerHealth>().currentHealth += energyAmmount;
                StartCoroutine(ActivationTime());
            }
        }
    }
}
