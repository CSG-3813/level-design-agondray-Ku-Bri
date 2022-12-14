using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Dialoge_Collider : MonoBehaviour
{
    public GameObject textWIN;
    public GameObject textLOSE;
    public Canvas canvas;

   

    private void Awake()
    {
        textWIN = transform.GetChild(6).gameObject;
        textLOSE = transform.GetChild(7).gameObject;

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
            textWIN.SetActive(false);
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
