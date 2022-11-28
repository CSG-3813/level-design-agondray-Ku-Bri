using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwingReverse : MonoBehaviour
{
    public AudioClip MainDoor;
    private Animator doorSwingRev;
    //AudioSource audioSrc;
    //AudioClip audioClp;


    // Start is called before the first frame update
    void Start()
    {
        doorSwingRev = GetComponent<Animator>();
        Debug.Log(doorSwingRev);
        //audioSrc = GetComponent<AudioSource>();
        //Debug.Log(audioSrc);
        //audioClp = GetComponent<AudioClip>();
        //Debug.Log(audioClp);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playHinge();
            doorSwingRev.SetBool("IsOpen", true);
            //AudioSource.PlayClipAtPoint(MainDoor, transform.position, 5);
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playHinge();
            doorSwingRev.SetBool("IsOpen", false);
            //AudioSource.PlayClipAtPoint(MainDoor, transform.position, 5);
        }
    }

   

    public void playHinge()
    {
        AudioSource.PlayClipAtPoint(MainDoor, transform.position, 35);
    }
}
