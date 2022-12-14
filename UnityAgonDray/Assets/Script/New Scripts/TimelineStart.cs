using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineStart : MonoBehaviour
{
    public PlayableDirector timeline;


    // Start is called before the first frame update
    void Start()
    {
        timeline = gameObject.GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeline.Play();
        }
    }
}
