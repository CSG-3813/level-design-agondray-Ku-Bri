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
   

    private void UpdateVisual()
    {
        if (GameManager.gameManager.hasKey)
        {
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, 0);
            keyTemplate.gameObject.SetActive(true);
        }
        
        
    }
}
