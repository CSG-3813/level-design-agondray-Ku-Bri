using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorPlayerLose : MonoBehaviour
{
    Animator anim;
    public GameObject beatAnimation;
    public GameObject beatAnimationBoss;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        beatAnimationBoss.SetActive(false);
        beatAnimation.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            beatAnimationBoss.SetActive(true);
            beatAnimation.SetActive(true);

        }
    }
}
