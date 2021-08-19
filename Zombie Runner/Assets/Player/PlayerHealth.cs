﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 100f;

    public void TakeDamage(float damage)
    {
        hitpoints -= damage;

        if (hitpoints <= 0f)
        {
            print("You dead, git gud");
        }
    }
}
