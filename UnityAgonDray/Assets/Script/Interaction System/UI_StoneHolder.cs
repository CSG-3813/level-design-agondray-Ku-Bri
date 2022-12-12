using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_StoneHolder : MonoBehaviour
{

    private Transform container;
    private Transform stoneTemplate;


    private void Awake()
    {
        container = transform.Find("container");
        stoneTemplate = container.Find("stoneTemplate");
        stoneTemplate.gameObject.SetActive(false);

    }

    private void Start()
    {

    }

    private void Update()
    {
        Debug.Log("In Update");
        if (GameManager.gameManager.hasStone)
        {
            Debug.Log("Has stone? " + GameManager.gameManager.hasStone);
            stoneTemplate.gameObject.SetActive(true);
        }
    }

    //private void UpdateVisual()
    //{
    //    //if (GameManager.gameManager.hasKey)
    //    //{
    //    //    keyTemplate.gameObject.SetActive(true);
    //    //}


    //}


}
