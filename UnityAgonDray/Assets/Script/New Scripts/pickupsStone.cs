using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupsStone : MonoBehaviour
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
            GameManager.gameManager.hasStone = true;
            Debug.Log(GameManager.gameManager.hasStone);
            AudioSource.PlayClipAtPoint(pickup, transform.position);
            Destroy(gameObject);
        }
    }
}
