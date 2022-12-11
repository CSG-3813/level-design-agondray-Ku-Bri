using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextDisplay: MonoBehaviour
{
    [Header("Text Boxes")]
    public TMP_Text mainTextbox; //textbox for the main body

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.gameManager.hasKey)
        {
           
        }
    }
}
