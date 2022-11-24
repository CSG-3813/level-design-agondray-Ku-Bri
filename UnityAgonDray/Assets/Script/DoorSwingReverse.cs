using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwingReverse : MonoBehaviour
{

    private Animator doorSwingRev;
    AudioSource audioSrc;
    AudioClip audioClp;


    // Start is called before the first frame update
    void Start()
    {
        doorSwingRev = GetComponent<Animator>();
        Debug.Log(doorSwingRev);
        audioSrc = GetComponent<AudioSource>();
        Debug.Log(audioSrc);
        audioClp = GetComponent<AudioClip>();
        Debug.Log(audioClp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            doorSwingRev.SetBool("IsOpen", true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        doorSwingRev.SetBool("IsOpen", false);
    }


    public void playHinge()
    {
        audioSrc.PlayOneShot(audioClp);
    }
}
