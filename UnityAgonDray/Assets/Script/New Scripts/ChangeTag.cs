using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangeTag: MonoBehaviour
{
    private void Start()
    {
        gameObject.tag = "Untagged";
    }
    public void tagChange()
    {
        gameObject.tag = "Enemy";
    }

    public void tagRevert()
    {
        gameObject.tag = "Untagged";
    }
}
