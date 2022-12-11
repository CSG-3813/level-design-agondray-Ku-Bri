using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] public HealthBar healthBar;

    public static GameManager gameManager { get; private set; }

    public UnitHealth playerHealth = new UnitHealth(100, 100);

    public bool hasKey = false;
    public bool hasStone = false;

    //public Sprite sprite;

   

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
        //gameObject.GetComponent<Renderer>().enabled = false;
        hasKey = false;
        hasStone = false;
    }

    private void Update()
    {
        
    }

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
