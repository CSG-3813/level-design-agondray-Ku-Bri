using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorColliderCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameManager.timer > 7)
        {
            gameObject.SetActive(true);
            Debug.Log("Triggers active again");
            GameManager.gameManager.trapTriggers = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trap collision detected.");
        if (other.CompareTag("Player"))
        {
            GameManager.gameManager.trapTriggers++;
            Debug.Log("trap count is " + GameManager.gameManager.trapTriggers);
            gameObject.SetActive(false);
        }
    }
}
