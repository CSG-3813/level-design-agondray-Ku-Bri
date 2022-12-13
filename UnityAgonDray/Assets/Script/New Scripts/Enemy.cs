using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Taking Damage");
            GameManager.gameManager.playerHealth.DmgUnit(20);
            Debug.Log(GameManager.gameManager.playerHealth);
        }
    }
    //public int HP = 100;
    //public Animator animator;

    //public void TakeDamage(int damageAmount)
    //{
    //    HP -= damageAmount;
    //    if(HP <= 0)
    //    {
    //        animator.SetTrigger("die");
    //    }
    //    else
    //    {
    //        animator.SetTrigger("damage");
    //    }
    //}
}
