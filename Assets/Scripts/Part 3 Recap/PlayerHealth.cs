using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth; // maximum health of player
    public int currentHealth; // current health of player
    void Start()
    {
        currentHealth = maxHealth;
    }
}

