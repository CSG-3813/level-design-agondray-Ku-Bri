using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    int currentHealth;
    int currentMaxHealth;

    public int Health
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return currentMaxHealth;
        }
        set
        {
            currentMaxHealth = value;
        }
    }

    public UnitHealth(int health, int maxHealth)
    {
        currentHealth = health;
        currentMaxHealth = maxHealth;
    }

    public void DmgUnit(int dmgAmount)
    {
        if(currentHealth > 0)
        {
            currentHealth -= dmgAmount;
        }
        if(currentHealth <= 0)
        {
            GameManager.gameManager.endMsg = GameManager.gameManager.loseMessage;
            GameManager.gameManager.SetTargetState(GameState.gameEnded); //set the state to Lost Level
        }
    }

    public void HealUnit(int healAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth += healAmount;
        }
        if(currentHealth > currentMaxHealth)
        {
            currentHealth = currentMaxHealth;
        }
    }
}
