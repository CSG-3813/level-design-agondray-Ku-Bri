using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Appear : MonoBehaviour
{
    GameObject textUI;

    private void Awake()
    {
        textUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameManager.gameManager.hasKey)
        //{
        //    textUI.SetActive(true);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textUI.SetActive(false);
        }
    }
}
