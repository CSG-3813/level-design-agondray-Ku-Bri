using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollsFall : MonoBehaviour
{
    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Anim.SetTrigger("Active");
            gameObject.SetActive(false);
        }
    }
}
