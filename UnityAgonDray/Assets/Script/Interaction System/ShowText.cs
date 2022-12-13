using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowText : MonoBehaviour
{
    public string textValue;
    public TMP_Text textElement;

    //public Canvas canvas;

    

    // Start is called before the first frame update
    void Start()
    {
        textElement.text = textValue;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered guard area");
            textElement.gameObject.SetActive(true);
            canvas.gameObject.SetActive(true);
        }
    }*/

    /*private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textElement.gameObject.SetActive(false);
            canvas.gameObject.SetActive(false);
        }
    }*/
}
