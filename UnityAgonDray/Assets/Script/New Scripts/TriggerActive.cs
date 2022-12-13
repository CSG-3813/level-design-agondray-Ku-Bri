using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActive : MonoBehaviour
{
    public TrapDoorManager TM;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        Debug.Log("Trigger Active");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected");
        if (other.CompareTag("Player"))
        {
            TM.triggerCount += 1;
            Debug.Log("Trigger count " + TM.triggerCount);
            gameObject.SetActive(false);
            Debug.Log("Trigger Inactive");
        }
    }

}
