using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshDeactivate : MonoBehaviour
{
    TrapDoorManager TDM;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger activated " + other.gameObject);
        if (other.CompareTag("Enemy") && TDM.triggerCount == 0) 
        {
            other.GetComponentInParent<NavMeshAgent>().enabled = false;
            Debug.Log("Trap is open " + other.GetComponentInParent<NavMeshAgent>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}
