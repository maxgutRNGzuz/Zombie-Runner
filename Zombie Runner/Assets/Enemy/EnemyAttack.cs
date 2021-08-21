using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 40f;

    PlayerHealth player;
    DestinationHealth destination;

    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        destination = FindObjectOfType<DestinationHealth>();
    }

    public void AttackHitEvent() //Animation Event Attack
    {
        if(player == null || destination == null)
        {
            return;
        }

        if(GetComponent<EnemyAI>().isProvoked == true)
        {
            player.TakeDamage(damage);
        }
        else
        {
            destination.TakeDamage(damage);
        }
    }

}
