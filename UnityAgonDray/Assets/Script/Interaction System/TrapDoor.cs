using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("buttonPushed", false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (GameManager.gameManager.trapTriggers == 3)
        {
            animator.SetBool("buttonPushed", true);
            GameManager.gameManager.timer += Time.deltaTime;
        }
        if (GameManager.gameManager.timer > 7)
        {
            animator.SetBool("buttonPushed", false);
            GameManager.gameManager.timer = 0;
        }*/
    }

    //public void TrapDoor()
    //{
        
    //}
}
