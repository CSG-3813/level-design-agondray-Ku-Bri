using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangeTag: MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        gameObject.tag = "Untagged";
        animator = gameObject.GetComponent<Animator>();
    }
    public void tagChange()
    {
        gameObject.tag = "Enemy";
    }

    public void tagRevert()
    {
        gameObject.tag = "Untagged";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndGameCollisionCheck"))
        {
            animator.SetBool("inPit", true);
            Application.Quit();
        }
    }
}
