using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_KeyHolder : MonoBehaviour
{

   private Transform container;
   private Transform keyTemplate;


    private void Awake()
    {
        container = transform.Find("container");
        keyTemplate = container.Find("keyTemplate");
        keyTemplate.gameObject.SetActive(false);

    }

    private void Start()
    {
            
    }

    private void Update()
    {
        if (GameManager.gameManager.hasKey)
        {
            keyTemplate.gameObject.SetActive(true);
        }
    }

    private void UpdateVisual()
    {
        //if (GameManager.gameManager.hasKey)
        //{
        //    keyTemplate.gameObject.SetActive(true);
        //}
        
        
    }


}
