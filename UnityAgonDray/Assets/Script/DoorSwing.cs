using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwing : MonoBehaviour
{
    public string animationParameter;
    Animator doorSwing;
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
            doorSwing.SetBool(animationParameter, true);
        }
    }


   public void playHinge()
    {
        audioSrc.PlayOneShot(audioClp);
    }
}
