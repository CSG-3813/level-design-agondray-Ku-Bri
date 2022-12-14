using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Dialoge_Collider1 : MonoBehaviour
{
    public string textWin;
    public string textLose;
    public Canvas canvas;

    public TMP_Text txtDisplay;




    private void Awake()
    {

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
            txtDisplay.text = textLose;
            canvas.gameObject.SetActive(true);
        }
        else
        {
            txtDisplay.text = textWin;
            canvas.gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(false);
        }
    }

}
