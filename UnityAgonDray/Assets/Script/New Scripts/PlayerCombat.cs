using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;


    public bool hasStick = false;
    public bool hasSword = false;

    public int noWeaponDamage = 10;
    public int stickDamage = 35;
    public int swordDamage = 50;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");
    }
}
