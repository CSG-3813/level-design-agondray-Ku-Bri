using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupsKey: MonoBehaviour
{
    
    public AudioClip pickup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.gameManager.hasKey = true;
            //Debug.Log(GameManager.gameManager.hasKey);
            AudioSource.PlayClipAtPoint(pickup, transform.position);
            Destroy(gameObject);
        }
    }
}
