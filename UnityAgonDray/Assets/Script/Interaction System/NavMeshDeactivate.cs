using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshDeactivate : MonoBehaviour
{
    NavMeshAgent agent;
    TrapDoorManager TDM;
    private bool inTrigger;


    private void Update()
    {
        if(inTrigger && TDM.triggerCount == 3)
        {
            agent.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger activated " + other.gameObject);
        if (other.CompareTag("Enemy")) 
        {
            agent = other.GetComponentInParent<NavMeshAgent>();
            
            agent.enabled = false;
            Debug.Log("Trap is open " + other.GetComponentInParent<NavMeshAgent>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            inTrigger = false;
            agent.enabled = true;
        }
    }
}
