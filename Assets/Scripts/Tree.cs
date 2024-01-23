using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float Health;
    public GameLogic GameLogic;

    public void TakeDamage(float damage)
    {
        Health -= damage;
        GameLogic.WoodCount++;
        if (Health < 0)
        {
            Destroy(gameObject);
        }
    }
}
