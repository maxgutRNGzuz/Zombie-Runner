using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;

    void Start()
    {
        
    }

    public void AttackHitEvent() //Animation Event Attack
    {
        if(target == null)
        {
            return;
        }

        print("Enemy attacking");
    }

}
