using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Dialoge_Collider : MonoBehaviour
{
    public GameObject textUI;
    public Canvas canvas;

   

    private void Awake()
    {
        textUI = transform.GetChild(0).gameObject;
        
    }

    private void Start()
    {

    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textUI.SetActive(false);
            canvas.gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(false);
            textUI.SetActive(false);
        }
    }

}
