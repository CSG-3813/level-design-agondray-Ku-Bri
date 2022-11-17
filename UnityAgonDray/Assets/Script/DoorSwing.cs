using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwing : MonoBehaviour
{

    public Animator doorSwing;


    // Start is called before the first frame update
    void Start()
    {
        doorSwing.enabled = false;
        doorSwing.SetBool("Door OpeN", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            doorSwing.SetBool("Door Open", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
