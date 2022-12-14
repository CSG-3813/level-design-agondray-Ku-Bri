using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfFall : MonoBehaviour
{
    Animator Anim;
    Collider col;
    private bool ePressed;

    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<Collider>();
        ePressed = false;
}

    /* Update is called once per frame
    void Update()
    {
        if(
        if (Input.GetMouseButtonDown(0))
       {
            Anim.SetTrigger("Active");
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Anim.SetTrigger("Active");
                ePressed = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && ePressed)
        {
            disableCollider();
        }
        
    }
    private void disableCollider()
    {
        col.enabled = !col.enabled;
    }
}
