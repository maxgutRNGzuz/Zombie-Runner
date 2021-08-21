using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 100f;

    public void TakeDamage(float damage)
    {
        hitpoints -= damage;

        if (hitpoints <= 0f)
        {
            print("Destination is destroyed, you lose ");
        }
    }
}
