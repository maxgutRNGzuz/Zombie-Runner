using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    float targetDistance = Mathf.Infinity;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        targetDistance = Vector3.Distance(target.position, transform.position);

        if(targetDistance <= chaseRange)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }

}
