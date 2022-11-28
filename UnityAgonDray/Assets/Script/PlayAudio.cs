using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        Debug.Log(aud);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound()
    {
        aud.Play();
    }
}
