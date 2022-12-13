using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupHEALTH : MonoBehaviour
{
    public AudioClip pickup;

   // GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
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
            GameManager.gameManager.healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);
            Debug.Log(GameManager.gameManager.playerHealth.Health + " slider moved");
            AudioSource.PlayClipAtPoint(pickup, transform.position);
            Destroy(gameObject);
        }
    }
}
