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

    //public int trapTriggers;
    //public float timer;
    

    [Header("GAME STATES")]
    public GameState currentGameState;
    public GameState targetGameState;
    public GameState lastGameState;

    [Header("SCENE SETTINGS")]
    [Tooltip("Name of the main menu (start) scene")]
    public string startScene;

    [Tooltip("Name of the game over (end) scene")]
    public string endScene;

    public static string currentSceneName; //the current scene name;

    [Tooltip("Count and name of each Game Level (scene)")]
    public string[] gameLevels; //names of levels
    [HideInInspector]
    public int gameLevelsCount; //what level we are on
    private int loadLevel; //what level from the array to load

    [Header("GAME MESSAGES")]
    public string defaultEndMessage = "Game Over";//the end screen message, depends on winning outcome
    public string loseMessage = "You Lose"; //Message if player loses
    public string winMessage = "You Win"; //Message if player wins
    [HideInInspector] public string endMsg;//the end screen message, depends on winning outcome



    [Header("FOR TESTING")]

    [SerializeField] //Access to private variables in editor
    [Tooltip("Check to test player lost the level")]
    private bool levelLost = false;//we have lost the level (ie. player died)

    //test next level
    [SerializeField] //Access to private variables in editor
    private bool levelBeat = false; //test for beating the level



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

        //store the current scene
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        //gameObject.GetComponent<Renderer>().enabled = false;
        hasKey = false;
        hasStone = false;
        //trapTriggers = 0;
        //timer = 0f;


        //if we run play the game from the level instead of start scene (PLAYTESTING ONLY)
        if (currentSceneName != startScene)
        {
            SetTargetState(GameState.gameTesting); //set the game state for testing
        }
        else
        {
            SetTargetState(GameState.gameStarted); //set the game state to game start
        }
    }

    private void Update()
    {
        //If ESC is pressed quit game
        if (Input.GetKey("escape")) { SetTargetState(GameState.gameExited); }

        //Game logic run every frame of current state
        UpdateCurrentState();
    }

    //Set the targeted game state
    public void SetTargetState(GameState gState)
    {
        targetGameState = gState;
        if (targetGameState != currentGameState)
        {
            lastGameState = currentGameState; //set the last game state to the current state
            UpdateTargetState();//run the target state update
        }

    }//end SetTargetState()

    //Record the current game state
    public GameState GetCurrentState()
    {
        return currentGameState;
    }//end GetCurrentState()


    //Update the target game state 
    public void UpdateTargetState()
    {
        // Do not run if state has not changed
        if (targetGameState == currentGameState) { return; }

        //Run once when target game state is set
        switch (targetGameState)
        {
            case GameState.gameStarted:
                Debug.Log("Game Starting");
                break;

            case GameState.gamePlaying:
                Debug.Log("Game Playing");
                //if (lastGameState == GameState.gameStarted) { SetGameDefaults(); } //HELP HERE
                StartGame();
                break;

            case GameState.gamePaused:
                break;

            case GameState.gameLevelEnded:
                Debug.Log("Level Ended");
                LoadLevel();//load next level
                break;

            case GameState.gameEnded:
                Debug.Log("Game Ended");

                if (winCondition) { endMsg = winMessage; }
                else { endMsg = loseMessage; }

                //if end scene does not exists
                if (endScene == null || endScene == "") { return; }
                //SetGameDefaults(); //rest game defaults 
                SceneManager.LoadScene(endScene);//load the end scene 
                break;

            case GameState.gameExited:
                Debug.Log("Game Exited");
                // UnityEditor.EditorApplication.isPlaying = false; can use if statement 
                Application.Quit();
                break;

            case GameState.gameTesting:
                Debug.Log("Game Testing");
                //SetGameDefaults();
                StartGame();
                break;

            default:
                break;
        }

        //Update the current state to the target state
        currentGameState = targetGameState;
        Debug.Log(currentGameState);

    }//end UpdateTargetState()


    //Update the current game state
    public void UpdateCurrentState()
    {
        //Looping logic for current game state
        switch (currentGameState)
        {
            case GameState.gameStarted:
                Debug.Log("Game is currently on title menu");
                break;

            case GameState.gamePlaying:
                Debug.Log("Game is currently running");
                break;

            case GameState.gamePaused:
                Debug.Log("Game is paused");
                break;

            case GameState.gameLevelEnded:
                Debug.Log("Game is currently level ended");
                break;

            case GameState.gameEnded:
                Debug.Log("Game is currently on end menu");
                break;

            case GameState.gameExited:
                Debug.Log("Game is exiting");
                break;

            case GameState.gameTesting:
                Debug.Log("Game is currently in test mode");
                RunTest();
                break;

            default:
                break;
        }
    }//end UpdateCurrentState()


    //called when we start the first game level
    void StartGame()
    {
        //get first game level
        gameLevelsCount = 1; //set the count for the game levels
        loadLevel = gameLevelsCount - 1; //the level from the array

        //load first game level
        SceneManager.LoadScene(gameLevels[loadLevel]);
    }//end StartGame()

    public void BeatLevel()
    {
        endMsg = winMessage;
        SetTargetState(GameState.gameLevelEnded);
    }//end BeatLevel()


    public void LostLevel()
    {
        endMsg = loseMessage;
        SetTargetState(GameState.gameLevelEnded);
    } //end LostLevel() 


    //Load Next Level
    void LoadLevel()
    {
        Debug.Log("Levels " + gameLevelsCount);
        //as long as our level count is not more than the amount of levels
        if (gameLevelsCount < gameLevels.Length)
        {
            gameLevelsCount++; //add to level count for next level
            loadLevel = gameLevelsCount - 1; //find the next level in the array
            SceneManager.LoadScene(gameLevels[loadLevel]); //load next level

            SetTargetState(GameState.gamePlaying);//if not we are playing

        }
        else
        { //if we have run out of levels go to game over
            SetTargetState(GameState.gameEnded);//if not we are playing
        } //end if (gameLevelsCount <=  gameLevels.Length)

    }//end NextLevel()


    //Run tests for game manager
    void RunTest()
    {
        Debug.Log("Run Test");

        //test for lossing level
        if (levelLost) { levelLost = false; }

        //test for winning level
        if (levelBeat) { levelBeat = false; BeatLevel(); }

    }//end RunTest()




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
