using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwing : MonoBehaviour
{
    
    private Animator doorSwing;
    AudioSource audioSrc;
    AudioClip audioClp;


    // Start is called before the first frame update
    void Start()
    {
        doorSwing = GetComponent<Animator>();
        Debug.Log(doorSwing);
        audioSrc = GetComponent<AudioSource>();
        Debug.Log(audioSrc);
        audioClp = GetComponent<AudioClip>();
        Debug.Log(audioClp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            doorSwing.SetBool("IsOpen", true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            doorSwing.SetBool("IsOpen", false);
        }
    }


    public void playHinge()
    {
        audioSrc.PlayOneShot(audioClp);
    }
}
