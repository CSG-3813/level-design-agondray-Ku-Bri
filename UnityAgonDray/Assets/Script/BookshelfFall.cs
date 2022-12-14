using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfFall : MonoBehaviour
{
    Animator Anim;
    private GameObject textUI;

    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        textUI = transform.GetChild(0).gameObject;
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
                Destroy(textUI);
                gameObject.GetComponent<UI_Dialoge_Collider>().enabled = false;
            }
        }
    }
}
