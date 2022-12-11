using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupHEALTH : MonoBehaviour
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
            GameManager.gameManager.playerHealth.HealUnit(15);
            Debug.Log(GameManager.gameManager.playerHealth.Health);
            AudioSource.PlayClipAtPoint(pickup, transform.position);
            Destroy(gameObject);
        }
    }
}
