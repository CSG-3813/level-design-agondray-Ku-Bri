using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshDeactivate : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            other.GetComponent<NavMeshAgent>().enabled = false;
        }
    }


}
