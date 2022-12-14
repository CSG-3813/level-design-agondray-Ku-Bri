using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Dialoge_Collider_Stone : MonoBehaviour
{
    public string textValue;
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
        if (other.CompareTag("Player") && GameManager.gameManager.hasStone)
        {
            txtDisplay.text = textValue;
            canvas.gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txtDisplay.text = "";
            canvas.gameObject.SetActive(false);

        }
    }

}
