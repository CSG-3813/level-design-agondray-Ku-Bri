using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoorSwing : MonoBehaviour
{
    public AudioClip MainDoor;
    private Animator doorSwing;
    //AudioSource audioSrc;
    //AudioClip audioClp;


    // Start is called before the first frame update
    void Start()
    {
        doorSwing = GetComponent<Animator>();
        //Debug.Log(doorSwing);
        //audioSrc = GetComponent<AudioSource>();
        //Debug.Log(audioSrc);
        //audioClp = GetComponent<AudioClip>();
        //Debug.Log(audioClp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameManager.gameManager.hasKey)
        {
            playHinge();
            doorSwing.SetBool("IsOpen", true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && GameManager.gameManager.hasKey)
        {
            playHinge();
            doorSwing.SetBool("IsOpen", false);
        }
    }


    public void playHinge()
    {
        AudioSource.PlayClipAtPoint(MainDoor, transform.position, 25);
    }
}
