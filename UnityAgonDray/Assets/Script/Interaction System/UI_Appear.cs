using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Appear : MonoBehaviour
{
    GameObject appearObject;

    private void Awake()
    {
        appearObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.hasKey)
        {
            appearObject.SetActive(true);
        }
    }

    
}
