using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
   

    //[SerializeField] HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("r"))
        //{
        //    PlayerTakeDamage(20);
        //    Debug.Log(GameManager.gameManager.playerHealth.Health);
        //}
        //if (Input.GetKeyDown("t"))
        //{
        //    PlayerHeal(15);
        //    Debug.Log(GameManager.gameManager.playerHealth.Health);
        //}
    }

    private void PlayerTakeDamage(int damage)
    {
        GameManager.gameManager.playerHealth.DmgUnit(damage);
        GameManager.gameManager.healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);
    }

    private void PlayerHeal(int healing)
    {
        GameManager.gameManager.playerHealth.HealUnit(healing);
        GameManager.gameManager.healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);
    }
}
