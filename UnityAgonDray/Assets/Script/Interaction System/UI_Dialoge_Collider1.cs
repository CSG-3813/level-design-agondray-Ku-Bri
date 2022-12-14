using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Dialoge_Collider1 : MonoBehaviour
{
    public GameObject textWIN;
    public GameObject textLOSE;
    public Canvas canvas;

   

    private void Awake()
    {
        textWIN = transform.GetChild(0).gameObject;
        textLOSE = transform.GetChild(1).gameObject;

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
            textLOSE.SetActive(false);
            canvas.gameObject.SetActive(true);
        }
        else
        {
            textWIN.SetActive(true);
            canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(false);
            textWIN.SetActive(false);
            textLOSE.SetActive(false);
        }
    }

}
