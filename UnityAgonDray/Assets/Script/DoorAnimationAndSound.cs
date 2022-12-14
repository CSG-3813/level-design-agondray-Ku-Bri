using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationAndSound : MonoBehaviour
{

    Animator anim;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetTrigger("Active");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        anim.enabled = true;
    }

    public void PauseAnimation()
    {
        anim.enabled = false;
    }

    //public void playHinge()
    //{
    //    sound.Play();
    //}
}
