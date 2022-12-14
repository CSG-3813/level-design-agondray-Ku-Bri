using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorManager : MonoBehaviour
{
    public int triggerCount;
    private float timer;
    Animator animator;

    private TriggerActive trigger;

    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject trigger3;
    public GameObject doorTrigger;

    // Start is called before the first frame update
    void Start()
    {   
        triggerCount = 0;
        animator = gameObject.GetComponent<Animator>();
        trigger1 = transform.GetChild(2).gameObject;
        trigger2 = transform.GetChild(3).gameObject;
        trigger3 = transform.GetChild(4).gameObject;
        doorTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerCount == 3)
        {
            animator.SetBool("TrapActive", true);
            doorTrigger.SetActive(true);
        }
    }

   
    public void TrapSystemReset()
    {
        triggerCount = 0;
        Debug.Log("triggerCount reset");
        animator.SetBool("TrapActive", false);
        Debug.Log("TrapAcive is false");
        //trigger.TriggerReset();
        trigger1.SetActive(true);
        Debug.Log("trigger1 reset");
        trigger2.SetActive(true);
        Debug.Log("trigger2 reset");
        trigger3.SetActive(true);
        Debug.Log("trigger3 reset");
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        //gameover animation and text
    //    }
    //    else
    //    {
    //        //you win animation and text
    //    }
    //}
}
