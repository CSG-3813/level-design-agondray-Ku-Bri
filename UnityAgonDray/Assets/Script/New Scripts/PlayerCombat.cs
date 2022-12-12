using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

   // public Animator animator;

    //public Transform attackPoint;
    //public float attackRange = 1f;
    //public LayerMask enemyLayer;

    //public bool hasStick = false;
    //public bool hasSword = false;

    //public int noWeaponDamage = 10;
    //public int stickDamage = 35;
    //public int swordDamage = 50;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Attack();
        //}
    }

    //void Attack()
    //{
    //    animator.SetTrigger("attack");

    //    Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

    //    foreach(Collider enemy in hitEnemies)
    //    {
    //        Debug.Log("We hit " + enemy.name);
    //    }
    //}


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Was Hit by " + collision.gameObject);
            GameManager.gameManager.playerHealth.DmgUnit(20);
            GameManager.gameManager.healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);
            Debug.Log(GameManager.gameManager.playerHealth.Health);
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    if (attackPoint == null)
    //    {
    //        return;
    //    }
    //        Gizmos.DrawWireSphere(attackPoint.position, attackRange);      
    //}
}
