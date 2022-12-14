using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //libraries for accessing scenes


public enum GameState { gameStarted, gamePlaying, gameEnded, gameLevelEnded, gamePaused, gameExited, gameTesting };
//enum of game states (work like it's own class)

public class GameManager : MonoBehaviour
{
    [SerializeField] public HealthBar healthBar;

    public static GameManager gameManager { get; private set; }

    public UnitHealth playerHealth = new UnitHealth(100, 100);

    public bool hasKey = false;
    public bool hasStone = false;

    public bool winCondition = false;
    public bool loseCondition = false;

    //public string winMessage;
    //public string loseMessage;
    //public string endMessage;

    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

    private void Start()
    {
        hasKey = false;
        hasStone = false;

        //winMessage = "You made it out alive!";
        //loseMessage = "You didn't quite make it...";
        //endMessage = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (winCondition || loseCondition)
        {
            Application.Quit();
        }
    }
    
    public void BeatLevel()
    {
        Application.Quit();
       
    }//end BeatLevel()


    public void LostLevel()
    {
        //endMessage = loseMessage;
        
    } //end LostLevel() 




    public void SetKey(bool val)
    {
        hasKey = val;
    }

    public bool GetKey()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        return hasKey;
    }

    public void SetStone(bool val)
    {
        hasStone = val;
    }

    public bool GetStone()
    {
        return hasStone;
    }

    


}
